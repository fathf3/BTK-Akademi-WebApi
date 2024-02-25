using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Book
{
	public record BookDtoForUpdate(int Id, String Title, decimal Price);
	//{
	//	// public record BookDtoForUpdate(int Id, String Title, decimal Price)
	//	// DTO -> readonly olmali, immutable degismez olmali, LINQ destegi 
	//	// DTO -> Ref Type , CTOR destekler
	//	// init -> tanımlandıgı yerde!!


	//	public int Id { get; init; } // immutable
	//	public String Title { get; init; }
 //       public decimal Price { get; init; }
 //   }
}
