﻿using ProductoAPI.Endpoints;
using RestauranteAPI.EndPoints;

namespace RestauranteAPI.Endpoints
{
    public static class ConfigureEndpoints
    {
        public static void UseEndpoints(this WebApplication app)
        {
            //MUESTRA EL ENDPOINT EN EL NAVEGADOR lueg de añadir el endponits se escrie esta linea
            //despues vamos a programar para agregar la interfaz
            UsuarioEndpoints.Add(app);
            ProductoEndpoints.Add(app);
            PedidoEndpoints.Add(app);
            DetallePedidoEndpoints.Add(app);
        }
    }
}
