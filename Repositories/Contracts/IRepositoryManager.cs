using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IRepositoryManager
	{
		// UnitOfWork pattern
		IBookRepository Book {  get; }
		ICategoryRepository Category { get; }
		Task SaveAsync(); // void -> Task


	}
}
