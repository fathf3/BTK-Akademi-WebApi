﻿using Entities.DataTransferObjects.Book;
using Entities.Exceptions;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using Presentation.ActionFilters;
using Services.Contracts;
using System.Text.Json;

namespace Presentation.Controllers
{
	[ApiVersion("1.0")]
	// Controller bazlı filtreleme
	[ServiceFilter(typeof(LogFilterAttribute))]
	[ApiController]
	[Route("api/books")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class BooksController : ControllerBase
	{
		private readonly IServiceManager _manager;

		public BooksController(IServiceManager manager)
		{
			_manager = manager;
		}

        [Authorize]
        [HttpHead]
		[HttpGet(Name ="GetAllBooksAsync")]
		public async Task<IActionResult> GetAllBooksAsync([FromQuery] BookParameters bookParameters)
		{
			var pagedResult = await _manager.BookService
				.GetAllBooksAsync(bookParameters, false);

			Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

			return Ok(pagedResult.books);

		}
        [Authorize]
        [HttpGet("{id:int}")]
		public async Task<IActionResult> GetOneBookAsync([FromRoute(Name = "id")] int id)
		{
			var book = await _manager
				.BookService
				.GetOneBookByIdAsync(id, false);

			return Ok(book);

		}

        [Authorize(Roles = "Admin, Editor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPost(Name = "CreateOneBookAsync")]
		public async Task<IActionResult> CreateOneBookAsync([FromBody] BookDtoForInsertion bookDto)
		{
			if (bookDto is null)
				return BadRequest(); //400

			// Valid degilse islemi birak -> ValidationAttributeFilter
			//if (!ModelState.IsValid)
			//	return UnprocessableEntity(ModelState);

			var book = await _manager.BookService.CreateOneBookAsync(bookDto);
			return StatusCode(201, book);

		}
        [Authorize(Roles = "Admin, Editor")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
		[HttpPut("{id:int}")]
		public async Task<IActionResult> UpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDto)
		{
			if (bookDto is null)
				return BadRequest();

			// ->[ServiceFilter(typeof(ValidationFilterAttribute))]
			//if (!ModelState.IsValid)
			//	return UnprocessableEntity(ModelState);

			await _manager.BookService.UpdateOneBookAsync(id, bookDto, false);

			return Ok(bookDto);
		}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteOneBookAsync([FromRoute(Name = "id")] int id)
		{

			await _manager.BookService.DeleteOneBookAsync(id, false);

			return Ok($"Book id : {id} deleted");

		}

		[HttpPatch("{id:int}")]
		public async Task<IActionResult> PartiallyUpdateOneBookAsync([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<BookDtoForUpdate> bookPatch)
		{
			if (bookPatch is null)
				return BadRequest(); // 400

			var result = await _manager.BookService.GetOneBookForPatchAsync(id, false);

			bookPatch.ApplyTo(result.bookDtoForUpdate);

			TryValidateModel(result.bookDtoForUpdate);

			if (!ModelState.IsValid)
				return UnprocessableEntity(ModelState);

			await _manager.BookService.SaveChangesForPatchAsync(result.bookDtoForUpdate, result.book);

			return NoContent(); // 204

		}
		[HttpOptions]
		public IActionResult GetBooksOptions()
		{
			Response.Headers.Add("Allow", "GET, PUT, POST, PATCH, DELETE, HEAD, OPTIONS");
			return Ok();
		}
	}
}
