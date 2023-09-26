using RestauranteAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.DTOs
{
    public class PedidoDTO
    {
        public int Id { get; set; }

        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        // Llave foránea
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
