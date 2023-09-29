using Microsoft.AspNetCore.Authorization;
using RestauranteAPI.DTOs;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.EndPoints
{
    public static class DetallePedidoEndpoints
    {
        public static void Add(this WebApplication app)
        {
            // Método Listar
            app.MapGet("api/detallepedidos", async (IDetallePedido _detallePedido) =>
            {
                var detallePedidos = await _detallePedido.DetallePedidos();

                // Código 200 - OK; la solicitud se creó correcatemente y se devuelve una lista
                return Results.Ok(detallePedidos);
            }).WithTags("DetallePedido").AllowAnonymous();

            // Método Buscar x id
            app.MapGet("api/detallepedidos/{id}", async (int id, IDetallePedido _detallePedido) =>
            {
                var detallePedido = await _detallePedido.DetallePedido(id);
                if (detallePedido == null)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.Ok(detallePedido); // Código 200 - OK; la solicitud se creó correcatemente
            }).WithTags("DetallePedido").AllowAnonymous();

            // Método Guardar
            app.MapPost("api/detallepedido", [Authorize] async (GuardarDetallePedido detallePedido, IDetallePedido _detallePedido) =>
            {
                if (detallePedido == null)
                    return Results.BadRequest(); // Código 400 Bad Request - La solicitud no se pudo                                              procesar, debido a un error de formato
                await _detallePedido.Crear(detallePedido);

                // Código 201 Created - El recurso se creó con éxito y se devuelve la ubicación del recurso creado
                return Results.Created("api/detallepedidos/{detallepedido.Id}", detallePedido);
            }).WithTags("DetallePedido");

            // Método Modificar
            app.MapPut("api/detallepedido/{id}", [Authorize] async (int id, GuardarDetallePedido detallePedido, IDetallePedido _detallePedido) =>
            {
                var resultado = await _detallePedido.Modificar(id, detallePedido);
                if (resultado == 0)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.Ok(resultado); // Código 200 - OK; la solicitud se creó correcatemente
            }).WithTags("DetallePedido");

            // Método Eliminar
            app.MapDelete("api/detallepedido/{id}", [Authorize] async (int id, IDetallePedido _detallePedido) =>
            {
                var resultado = await _detallePedido.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // Código 404 Not Found - El recurso solicitado no existe
                else
                    return Results.NoContent(); // Código 204 - NO Content; el recurso se eliminó con éxito
            }).WithTags("DetallePedido");
        }
    }
}
