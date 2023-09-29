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
            }).WithTags("Usuario");

            // Login
            app.MapPost("api/login", async (UsuarioLogin usuario, IUsuario _usuario) => {
                var login = await _usuario.Login(usuario);
                if (login is null)
                    return Results.NotFound(new { mensaje = "Usuario o contraseña incorrecto" });
                var token = _usuario.GenerarToken(login);
                login.Clave = string.Empty;
                if (string.IsNullOrEmpty(token))
                {
                    return Results.Unauthorized();
                }
                else
                {
                    return Results.Ok(token);
                }
            }).WithTags("Usuario");
        }
    }
}
