using BookDemo.Models;

namespace BookDemo.Data
{
	public static class AppContext
	{
        public static List<Book> Books {  get; set; } 
        static AppContext()
        {
            Books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "Kitap 1",
                    Price = 10,
                },
				new Book
				{
					Id = 2,
					Title = "Kitap 2",
					Price = 20,
				},
				new Book
				{
					Id = 3,
					Title = "Kitap 3",
					Price = 30,
				},
			};
        }

    }
}
