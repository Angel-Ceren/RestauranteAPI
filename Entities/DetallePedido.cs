using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Entities
{
    public class DetallePedido
    {
        // Llave primaria
        [Key]
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }

        // Llaves foráneas
        [ForeignKey(nameof(Pedido))]

        public int PedidoID { get; set; }

        public Pedido Pedido { get; set; }

        [ForeignKey(nameof(Producto))]

        public int ProductoID { get; set; }

        public Producto Producto { get; set; }
    }
}
