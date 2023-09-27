namespace RestauranteAPI.Endpoints
{
    public static class ConfigureEndpoints
    {
        public static void UseEndpoints(this WebApplication app)
        {
            //MUESTRA EL ENDPOINT EN EL NAVEGADOR lueg de añadir el endponits se escrie esta linea
            //despues vamos a program para agregar la interfaz
            ProductoEndpoints.Add(app);
        }
    }
}
