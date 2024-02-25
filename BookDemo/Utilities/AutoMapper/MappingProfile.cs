using AutoMapper;
using Entities.DataTransferObjects.Book;
using Entities.Models;

namespace BookDemo.Utilities.AutoMapper
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<BookDtoForUpdate, Book>();
        }
    }
}
