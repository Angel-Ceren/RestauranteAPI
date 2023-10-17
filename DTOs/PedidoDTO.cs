using RestauranteAPI.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.DTOs
{
    // Se ocupa para el endpoint listar
    public class PedidoDTO
    {
        public int Id { get; set; }

        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        // Llave foránea
        public int UsuarioId { get; set; }

        public InfoUsuario Usuario { get; set; }
    }

    // Se ocupa para el endpoint de crear/guardar
    public class GuardarPedido
    {
        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        // Llave foránea
        public int UsuarioId { get; set; }
    }

    public class EliminarPedido
    {
        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }
    }
}
