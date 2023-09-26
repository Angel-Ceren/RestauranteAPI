namespace RestauranteAPI.DTOs
{
    public class UsuarioDTO
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}