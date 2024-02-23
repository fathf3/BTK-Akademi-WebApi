using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected RepositoryContext _context;

		public RepositoryBase(RepositoryContext context)
		{
			_context = context;
		}
		// _context.Set<T>() surekli yazmaktan kuratırır.
		private DbSet<T> Table { get => _context.Set<T>(); }

		public void Create(T entity) => Table.Add(entity);

		public void Delete(T entity) => Table.Remove(entity);

		public IQueryable<T> FindAll(bool trackChanges) => !trackChanges ?
			Table.AsNoTracking() :
			Table;

		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
		=> !trackChanges ? 
			Table.Where(expression).AsNoTracking() :
			Table.Where(expression);

		public void Update(T entity) => Table.Update(entity);
	}
}
