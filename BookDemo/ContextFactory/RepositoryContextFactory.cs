using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repositories.EFCore;

namespace BookDemo.ContextFactory
{
	public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
	{
		public RepositoryContext CreateDbContext(string[] args)
		{
			// configurationBuilder
			var configuration = new  ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			// DbContextOptionBuilder
			var builder = new DbContextOptionsBuilder<RepositoryContext>()
				.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
				prj => prj.MigrationsAssembly("BookDemo"));
			
			return new RepositoryContext(builder.Options);
 
		}
	}
}
