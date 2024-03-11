﻿using Entities.DataTransferObjects.Book;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IBookService
	{
		Task<(IEnumerable<ShapedEntity> books, MetaData metaData)> GetAllBooksAsync(BookParameters bookParameters, bool trackChanges);
		Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges);
		Task<BookDto> CreateOneBookAsync(BookDtoForInsertion book);
		Task UpdateOneBookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges);
		Task DeleteOneBookAsync(int id, bool trackChanges);


		Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetOneBookForPatchAsync(int id, bool trackChanges);
		Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book);
		Task<List<Book>> GetAllBooksAsync(bool trackChanges);
	}
}
