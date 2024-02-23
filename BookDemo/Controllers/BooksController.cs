using BookDemo.Data;
using BookDemo.Models;
using Microsoft.AspNetCore.Http;
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








	}
}
