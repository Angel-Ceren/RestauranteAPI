namespace RestauranteAPI.DTOs
{
    public class UsuarioDTO
    {   // SE CREO NUESTRO DTO PARA LUEGO MAPEARLO
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
    }

    public class UsuarioLogin
    {   // SE CREO NUESTRO DTO PARA LUEGO MAPEARLO

        public string Nombre { get; set; }
        public string Clave { get; set; }
    }
}