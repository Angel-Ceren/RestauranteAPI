using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.Repositories
{
    public class DetallePedidoRepository : IDetallePedido
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        // Constructor
        public DetallePedidoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Implementación de interfaz
        public async Task<DetallePedidoDTO> DetallePedido(int id)
        {
            var entidad = await _db.DetallePedidos.FindAsync(id);
            var detallepedido = _mapper.Map<DetallePedido, DetallePedidoDTO>(entidad);

            return detallepedido;
        }

        public async Task<ICollection<DetallePedidoDTO>> DetallePedidos()
        {
            var entidades = await _db.DetallePedidos.Include(x => x.Producto).ToListAsync();
            var entidad = await _db.DetallePedidos.Include(x => x.Pedido).ToListAsync();

            var detallepedidos = _mapper.Map<ICollection<DetallePedido>, ICollection<DetallePedidoDTO>>(entidades);
            var detallepedido = _mapper.Map<ICollection<DetallePedido>, ICollection<DetallePedidoDTO>>(entidad);

            return detallepedidos;
        }

        public async Task<int> Crear(GuardarDetallePedido detallePedido)
        {
            var entidad = _mapper.Map<GuardarDetallePedido, DetallePedido>(detallePedido);
            await _db.DetallePedidos.AddAsync(entidad);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> Eliminar(int id)
        {
            var pedido = await _db.DetallePedidos.FindAsync(id);
            if (pedido == null)
                return 0;

            _db.DetallePedidos.Remove(pedido);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, GuardarDetallePedido detallePedido)
        {
            var entidad = await _db.DetallePedidos.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Cantidad = detallePedido.Cantidad;
            entidad.PrecioUnitario = detallePedido.PrecioUnitario;
            entidad.Subtotal = detallePedido.Subtotal;

            _db.DetallePedidos.Update(entidad);
            return await _db.SaveChangesAsync();
        }
    }
}
