namespace Entities.RequestFeatures
{
	public class BookParameters : RequestParameters
	{
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 10000;

        public bool ValidPriceRange => MaxPrice > MinPrice;

        public String? SearchTerm { get; set; }

        public BookParameters()
		{
            // Eger bir sıralama girilmediyse Id ye gore sıralar
			OrderBy = "id"; 
        }

    }


}
