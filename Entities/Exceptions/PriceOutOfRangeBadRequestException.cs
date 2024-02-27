namespace Entities.Exceptions
{
	public class PriceOutOfRangeBadRequestException : BadRequestException
	{
		public PriceOutOfRangeBadRequestException() : base("Maximum price should be less than 10000 and greater than 10.")
		{

		}
	}
}
