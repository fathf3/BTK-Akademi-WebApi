using AutoMapper;
using Entities.DataTransferObjects.Book;
using Entities.DataTransferObjects.User;
using Entities.Models;

namespace BookDemo.Utilities.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BookDtoForUpdate, Book>().ReverseMap();
			CreateMap<BookDtoForInsertion, Book>().ReverseMap();
			CreateMap<BookDto, Book>().ReverseMap();
			CreateMap<UserForRegistrationDto, User>().ReverseMap();
		}
	}
}
