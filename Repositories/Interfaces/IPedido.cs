using RestauranteAPI.DTOs;

namespace RestauranteAPI.Repositories.Interfaces
{
    public interface IPedido
    {
        Task<int> Crear(GuardarPedido pedido);

        Task<ICollection<PedidoDTO>> Pedidos();

        Task<PedidoDTO> Pedido(int id);

        Task<int> Modificar(int id, GuardarPedido pedido);

        Task<int> Eliminar(int id);
    }
}
