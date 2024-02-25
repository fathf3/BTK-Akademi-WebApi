namespace Entities.DataTransferObjects.Book
{

	
	public record BookDto
	{
		// bu kullanımda [Serializable] kullanmaya gerek kalmaz
		public int Id { get; set; }
        public String Title { get; set; }
        public decimal Price { get; set; }
    }
	
}
