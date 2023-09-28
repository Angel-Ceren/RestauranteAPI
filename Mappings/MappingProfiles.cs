using AutoMapper;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;

namespace RestauranteAPI.Mappings
{
    public class MappingProfiles : Profile
    { 
        public MappingProfiles()
        {
            // Entidad --> DTO
            // Usuario  
            CreateMap<Usuario, UsuarioDTO>();
            // Pedido
            CreateMap<Pedido, PedidoDTO>();
            //CreateMap<Pedido, GuardarPedido>();

            // DTO --> entidad
            // Usuario
            CreateMap<UsuarioDTO, Usuario>();
            // Pedido
            CreateMap<PedidoDTO, Pedido>();
            //CreateMap<GuardarPedido, Pedido>();

        }
    }
}

