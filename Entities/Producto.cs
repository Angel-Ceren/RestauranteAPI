using System.ComponentModel.DataAnnotations;

namespace RestauranteAPI.Entities
{
    public class Producto
    {
        // Llave primaria
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
    }
}
