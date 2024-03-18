using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
	[ApiVersion("2.0")]
	[ApiController]
	[Route("api/{v:apiversion}/books")]
	[ApiExplorerSettings(GroupName = "v2")]
	public class BooksV2Controller : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public BooksV2Controller(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllBooks()
		{
			var books = await _serviceManager.BookService.GetAllBooksAsync(false);

			return Ok(books);
		}
	}
}
