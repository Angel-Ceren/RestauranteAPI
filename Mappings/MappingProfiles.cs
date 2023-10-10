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
            CreateMap<Usuario, InfoUsuario>();
            // Pedido
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<Pedido, GuardarPedido>();
            CreateMap<Pedido, EliminarPedido>();
            //Producto
            CreateMap<Producto, ProductoDTO>();
            // DetallePedido
            CreateMap<DetallePedido, DetallePedidoDTO>();
            CreateMap<DetallePedido, GuardarDetallePedido>();
            CreateMap<DetallePedido, EliminarDetallePedido>();

            // DTO --> entidad
            // Usuario
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<InfoUsuario, Usuario>();
            // Pedido
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<GuardarPedido, Pedido>();
            CreateMap<EliminarPedido, Pedido>();
            //Producto
            CreateMap<ProductoDTO, Producto>();
            // DetallePedido
            CreateMap<DetallePedidoDTO, DetallePedido>();
            CreateMap<GuardarDetallePedido, DetallePedido>();
            CreateMap<EliminarDetallePedido, DetallePedido>();
        }
    }
}

