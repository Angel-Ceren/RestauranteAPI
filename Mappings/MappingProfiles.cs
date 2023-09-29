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
            CreateMap<Pedido, GuardarPedido>();
            //Producto
            CreateMap<Producto, ProductoDTO>();
            // DetallePedido
            CreateMap<DetallePedido, DetallePedidoDTO>();
            CreateMap<DetallePedido, GuardarDetallePedido>();

            // DTO --> entidad
            // Usuario
            CreateMap<UsuarioDTO, Usuario>();
            // Pedido
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<GuardarPedido, Pedido>();
            //Producto
            CreateMap<ProductoDTO, Producto>();
            // DetallePedido
            CreateMap<DetallePedidoDTO, DetallePedido>();
            CreateMap<GuardarDetallePedido, DetallePedido>();
        }
    }
}

