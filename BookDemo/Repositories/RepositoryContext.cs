using BookDemo.Models;
using BookDemo.Repositories.Config;
using Microsoft.EntityFrameworkCore;

namespace BookDemo.Repositories
{
	public class RepositoryContext : DbContext
	{

        public RepositoryContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BookConfig());
		}
	}


}
