using Entities.DataTransferObjects.Book;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/books")]
	public class BooksController : ControllerBase
	{
		private readonly IServiceManager _manager;

		public BooksController(IServiceManager manager)
		{
			_manager = manager;
		}

		[HttpGet]
		public IActionResult GetAllBooks()
		{
			try
			{
				var books = _manager.BookService.GetAllBooks(false);
				return Ok(books);

			}
			catch (Exception ex)
			{

				throw new Exception(ex.Message);
			}


		}

		[HttpGet("{id:int}")]
		public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
		{
			var book = _manager
				.BookService
				.GetOneBookById(id, false);

			return Ok(book);

		}

		[HttpPost]
		public IActionResult CreateOneBook([FromBody] Book book)
		{
			try
			{
				if (book is null)
					return BadRequest(); //400

				_manager.BookService.CreateOneBook(book);

				return StatusCode(201, book);

			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}

		}

		[HttpPut("{id:int}")]
		public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
		{
			_manager.BookService.UpdateOneBook(id, bookDto, true);

			return Ok(bookDto);
		}

		[HttpDelete("{id:int}")]
		public IActionResult DeleteOneBook([FromRoute(Name = "id")] int id)
		{

			_manager.BookService.DeleteOneBook(id, false);

			return Ok($"Book id : {id} deleted");

		}
		
		[HttpPatch("{id:int}")]
		public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatch)
		{
			var entity = _manager.BookService.GetOneBookById(id, true);
			
			bookPatch.ApplyTo(entity);
			_manager.BookService.UpdateOneBook(id, new BookDtoForUpdate(entity.Id, entity.Title, entity.Price), true);
			return NoContent();
		}
	}
}
