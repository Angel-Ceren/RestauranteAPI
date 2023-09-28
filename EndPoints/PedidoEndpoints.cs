using Microsoft.AspNetCore.Authorization;
using RestauranteAPI.DTOs;
using RestauranteAPI.Entities;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.EndPoints
{
    public static class PedidoEndpoints
    {
        public static void Add(this WebApplication app)
        {
            // Método Listar
            app.MapGet("api/pedidos", async (IPedido _pedido) => {
                var productos = await _pedido.Pedidos();

                // Código 200 - OK; la solicitud se creó correcatemente y se devuelve una lista
                return Results.Ok(productos);
            }).WithTags("Pedido").AllowAnonymous();

            // Método Buscar x id
            app.MapGet("api/pedidos/{id}", async (int id, IPedido _pedido) => {
                var pedido = await _pedido.Pedido(id);
                if (pedido == null)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.Ok(pedido); // Código 200 - OK; la solicitud se creó correcatemente
            }).WithTags("Pedido").AllowAnonymous();

            // Método Guardar
            app.MapPost("api/pedido", [Authorize] async (GuardarPedido pedido, IPedido _pedido) => {
                if (pedido == null)
                    return Results.BadRequest(); // Código 400 Bad Request - La solicitud no se pudo                                              procesar, debido a un error de formato
                await _pedido.Crear(pedido);

                // Código 201 Created - El recurso se creó con éxito y se devuelve la ubicación del recurso creado
                return Results.Created("api/pedidos/{pedido.Id}", pedido);
            }).WithTags("Pedido");

            // Método Modificar
            app.MapPut("api/pedido/{id}", [Authorize] async (int id, GuardarPedido pedido, IPedido _pedido) => {
                var resultado = await _pedido.Modificar(id, pedido);
                if (resultado == 0)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.Ok(resultado); // Código 200 - OK; la solicitud se creó correcatemente
            }).WithTags("Pedido");

            // Método Eliminar
            app.MapDelete("api/pedido/{id}", [Authorize] async (int id, IPedido _pedido) => {
                var resultado = await _pedido.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.NoContent(); // Código 204 - NO Content; el recurso se eliminó con éxito
            }).WithTags("Pedido");
        }
    }
}
