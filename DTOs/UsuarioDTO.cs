namespace RestauranteAPI.DTOs
{
    public class UsuarioDTO
    {   // SE CREO NUESTRO DTO PARA LUEGO MAPEARLO
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }

    public class UsuarioLogin
    {   // SE CREO NUESTRO DTO PARA LUEGO MAPEARLO

        public string Correo { get; set; }
        public string Clave { get; set; }
    }

    public class InfoUsuario
    {   // SE CREO NUESTRO DTO PARA LUEGO MAPEARLO
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
    }
}