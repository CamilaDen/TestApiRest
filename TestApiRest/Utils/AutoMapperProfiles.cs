using AutoMapper;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Utils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<Libro,LibroDTO>();  
            CreateMap<LibroDTO,Libro>();
            CreateMap<Pedido,PedidoDTO>();
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<DetallePedido, DetallePedidoDTO>();
            CreateMap<DetallePedidoDTO, DetallePedido>(); 
        }
    }
}
