using RestauranteAPI.DTOs;

namespace RestauranteAPI.Repositories.Interfaces
{
    public interface IProducto
    {
        Task<int> Crear(ProductoDTO producto);

        Task<ICollection<ProductoDTO>> Productos();

        Task<ProductoDTO> Producto(int id);

        Task<int> Modificar(int id, ProductoDTO producto);

        Task<int> Eliminar(int id);
    }
}
