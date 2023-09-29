using RestauranteAPI.DTOs;

namespace RestauranteAPI.Repositories.Interfaces
{
    public interface IDetallePedido
    {
        Task<int> Crear(GuardarDetallePedido detallePedido);

        Task<ICollection<DetallePedidoDTO>> DetallePedidos();

        Task<DetallePedidoDTO> DetallePedido(int id);

        Task<int> Modificar(int id, GuardarDetallePedido detallePedido);

        Task<int> Eliminar(int id);
    }
}
