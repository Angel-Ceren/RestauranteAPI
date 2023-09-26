namespace RestauranteAPI.Entities
{
    public class Producto
    {
        
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public bool Disponible { get; set; }
        public string Imagen { get; set; }
    }
}
