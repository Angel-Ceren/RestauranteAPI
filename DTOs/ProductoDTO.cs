namespace RestauranteAPI.DTOs
{
    public class ProductoDTO
    {   //Creacion de nuestro DTO para la entidad Productos 
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
    }
}
