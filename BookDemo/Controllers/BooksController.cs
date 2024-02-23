using BookDemo.Data;
using BookDemo.Models;
using BookDemo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AppContext = BookDemo.Data.AppContext;

namespace BookDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly RepositoryContext _context;

		public BooksController(RepositoryContext context)
		{
			_context = context;
		}

		[HttpGet]
		public IActionResult GetAllBooks()
		{
			try
			{
				var books = _context.Books.ToList();
				return Ok(books);

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			
			
		}

		[HttpGet("{id:int}")]
		public IActionResult GetOneBook([FromRoute(Name = "id")]int id)
		{
			try
			{
				var book = _context
				.Books
				.Where(b => b.Id.Equals(id))
				.SingleOrDefault();
				return Ok(book);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			
			
		}

		[HttpPost]
		public IActionResult CreateOneBook([FromBody]Book book)
		{
			try
			{
				if (book is null)
					return BadRequest(); //400

				_context.Books.Add(book);
				_context.SaveChanges();
				return StatusCode(201, book);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
			
		}

		[HttpPut("{id:int}")]
		public IActionResult UpdateOneBook([FromRoute(Name ="id")]int id,[FromBody] Book book)
		{
			try
			{
				var entity = _context
				.Books
				.Where(b => b.Id == id)
				.SingleOrDefault();

				if (entity is null)
					return NotFound();


				entity.Title = book.Title;
				entity.Price = book.Price;
				_context.SaveChanges();

				return Ok(book);
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
		{
			try
			{
				var book = _context.Books
				.Where(b => b.Id == id)
				.SingleOrDefault();

				if (book is null)
					return NotFound(new
					{
						statusCode = 404,
						message = $"Book with id : {id} could not found"
					}); // 404

				_context.Books.Remove(book);
				_context.SaveChanges();
				return Ok($"Book id : {id} deleted");
			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}
			
		}

       
    }
}
