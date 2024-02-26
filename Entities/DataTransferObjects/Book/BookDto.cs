namespace Entities.DataTransferObjects.Book
{

	
	public record BookDto
	{
		// bu kullanımda [Serializable] kullanmaya gerek kalmaz
		public int Id { get; init; }
        public String Title { get; init; }
        public decimal Price { get; init; }
    }
	
}
