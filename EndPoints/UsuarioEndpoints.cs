using RestauranteAPI.DTOs;
using RestauranteAPI.Repositories.Interfaces;

namespace RestauranteAPI.EndPoints
{
    public static class UsuarioEndpoints
    {
        public static void Add(this WebApplication app)
        {
            // Método Guardar
            app.MapPost("api/usuario", async (UsuarioDTO usuario, IUsuario _usuario) =>
            {
                if (usuario == null)
                    return Results.BadRequest(); // Código 400 Bad Request - La solicitud no se pudo                                              procesar, debido a un error de formato
                await _usuario.Crear(usuario);

                // Código 201 Created - El recurso se creó con éxito y se devuelve la ubicación del recurso creado
                return Results.Created("api/usuario/{usuario.Id}", usuario);
            }).WithTags("usuario").WithTags("Usuarios");
        }
    }
}
