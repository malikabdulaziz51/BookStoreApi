using AutoMapper;
using BookStoreApi.Dto;

namespace BookStoreApi.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Book, BookCoverDto>();
        }
    }
}
