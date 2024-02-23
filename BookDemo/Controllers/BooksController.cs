using BookDemo.Data;
using BookDemo.Models;
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

		[HttpGet]
		public IActionResult GetAllBooks()
		{
			var books = AppContext.Books;
			return Ok(books);
		}
		[HttpGet("{id:int}")]
		public IActionResult GetOneBook([FromRoute(Name = "id")]int id)
		{ 
			var book = AppContext
				.Books
				.Where(b => b.Id.Equals(id))
				.SingleOrDefault();
			if (book == null)
				return NotFound($"Bu id : {id} numralı kitap bulunamadı"); 
			return Ok(book);
		}
		[HttpPost]
		public IActionResult CreateOneBook([FromBody]Book book)
		{
			try
			{
				if (book is null)
					return BadRequest(); //400

				AppContext.Books.Add(book);
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
			var entity = AppContext
				.Books
				.Find(b => b.Id == id);	

			if(entity is null)
				return NotFound();
			AppContext.Books.Remove(entity);
			
			book.Id = entity.Id;
			AppContext.Books.Add(book);
			return Ok(book);
		}

		[HttpDelete]
		public IActionResult DeleteAllBooks()
		{
			
			AppContext.Books.Clear();
			return NoContent(); // 204
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
		{
			var book = AppContext.Books.Find(b => b.Id == id);
			if(book is null)
				return NotFound(new
				{
					statusCode = 404,
					message = $"Book with id : {id} could not found"
				}); // 404
			AppContext.Books.Remove(book);
			return Ok($"Book id : {id} deleted");
		}

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
		{
			var entity = AppContext.Books.Find(b => b.Id == id);
			if(entity is null)
				return NotFound(); //404
			bookPatch.ApplyTo(entity);
			return NoContent(); // 204
		} 

    }
}
