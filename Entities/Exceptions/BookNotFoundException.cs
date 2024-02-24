namespace Entities.Exceptions
{
	public sealed class BookNotFoundException : NotFoundException
    {
		// Bu class dan kalıtım yapılamaz
        public BookNotFoundException(int id) : base($"The book with id {id} could not found.")
        {

        }
	}


}
