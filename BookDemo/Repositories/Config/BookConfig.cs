using BookDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookDemo.Repositories.Config
{
	public class BookConfig : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.HasData(
				 new Book { Id = 1, Title = "Karagoz", Price = 100 },
				 new Book { Id = 2, Title = "Sherlock", Price = 200 },
				 new Book { Id = 3, Title = "Nutuk", Price = 300 }
				);
		}
	}
}
