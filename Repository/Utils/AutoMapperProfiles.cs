using AutoMapper;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<Book,BookDTO>();  
            CreateMap<BookDTO,Book>();
            CreateMap<Order,OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderDetail, OrderDetailDTO>();
            CreateMap<OrderDetailDTO, OrderDetail>();

        }
    }
}
