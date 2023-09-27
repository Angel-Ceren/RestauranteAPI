using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.Repositories
{
    public class ProductoRepository : IProducto //Implemtar interfaz luego de realizar el constructor
    {
        //Se marco _db y _mapper, acciones rapidas,,,

        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProductoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Crear(ProductoDTO producto)
        {
            var entidad = _mapper.Map<ProductoDTO, Producto>(producto);
            await _db.Productos.AddAsync(entidad);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> Eliminar(int id)
        {
            var producto = await _db.Productos.FindAsync(id);
            if (producto == null)
                return 0;

            _db.Productos.Remove(producto);
            return await Guardar();
        }

        private async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ProductoDTO producto)
        {
            var entidad = await _db.Productos.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = producto.Nombre;
            entidad.Descripcion = producto.Descripcion;
            entidad.Precio = producto.Precio;
            entidad.Categoria = producto.Categoria;
            entidad.Cantidad = producto.Cantidad;
            entidad.Imagen = producto.Imagen;
            //En caso tuviera otra entidad
            //entidad.Descripcion = categoria.Descripcion;
            _db.Productos.Update(entidad);
            return await Guardar();
        }

        public async Task<ProductoDTO> Producto(int id)
        {
            var entidad = await _db.Productos.FindAsync(id);
            var producto = _mapper.Map<Producto, ProductoDTO>(entidad);

            return producto;
        }

        public async Task<ICollection<ProductoDTO>> Productos()
        {
            var entidades = await _db.Productos.ToListAsync();
            var productos = _mapper.Map<ICollection<Producto>, ICollection<ProductoDTO>>(entidades);

            return productos;
        }
    }
}
