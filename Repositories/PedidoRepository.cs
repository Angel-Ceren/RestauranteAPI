using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Context;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.Repositories
{
    public class PedidoRepository : IPedido
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;

        // Constructor
        public PedidoRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        // Implementación de interfaz
        public async Task<PedidoDTO> Pedido(int id)
        {
            var entidad = await _db.Pedidos.FindAsync(id);
            var pedido = _mapper.Map<Pedido, PedidoDTO>(entidad);

            return pedido;
        }

        public async Task<ICollection<PedidoDTO>> Pedidos()
        {
            var entidades = await _db.Pedidos.Include(x => x.Usuario).ToListAsync();

            var pedidos = _mapper.Map<ICollection<Pedido>, ICollection<PedidoDTO>>(entidades);

            return pedidos;
        }

        public async Task<int> Crear(GuardarPedido pedido)
        {
            var entidad = _mapper.Map<GuardarPedido, Pedido>(pedido);
            await _db.Pedidos.AddAsync(entidad);

            return await _db.SaveChangesAsync();
        }

        public async Task<int> Eliminar(int id)
        {
            var pedido = await _db.Pedidos.FindAsync(id);
            if (pedido == null)
                return 0;

            _db.Pedidos.Remove(pedido);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, GuardarPedido pedido)
        {
            var entidad = await _db.Pedidos.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.FechaPedido = pedido.FechaPedido;
            entidad.Estado = pedido.Estado;
            entidad.Total = pedido.Total;

            _db.Pedidos.Update(entidad);
            return await _db.SaveChangesAsync();
        }
    }
}
