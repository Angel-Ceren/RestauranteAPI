using RestauranteAPI.Entities;

namespace RestauranteAPI.DTOs
{
    // Se ocupa para el endpoint listar
    public class DetallePedidoDTO
    {
        // Llave primaria
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Llaves foráneas
        public int PedidoID { get; set; }
        public Pedido Pedido { get; set; }

        public int ProductoID { get; set; }
        public Producto Producto { get; set; }
    }


    // Se ocupa para el endpoint de crear/guardar
    public class GuardarDetallePedido
    {
        // Llave primaria
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }

        // Llaves foráneas
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
    }
}
