using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestauranteAPI.Entities
{
    public class Pedido
    {
        // Llave primaria
        [Key]
        public int Id { get; set; }

        public DateTime FechaPedido { get; set; }

        public string Estado { get; set; }

        public decimal Total { get; set; }

        // Llave foránea
        [ForeignKey(nameof(Usuario))]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
    }
}
