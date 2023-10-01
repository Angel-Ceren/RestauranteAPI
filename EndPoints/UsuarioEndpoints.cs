using RestauranteAPI.DTOs;
using RestauranteAPI.Repositories.Interfaces;

namespace ProductoAPI.Endpoints
{
    //agregar el static class
    public static class UsuarioEndpoints
    {
        public static void Add(this WebApplication app)
        {

            //Metodo Guardar
            app.MapPost("api/usuario", async (UsuarioDTO usuario, IUsuario _usuario) =>
            {
                if (usuario == null)
                    return Results.BadRequest(); // BadRequest la solicitud no se pudo
                                                 //procesar, debido a un error de formato

                await _usuario.Crear(usuario);
                //201 Created - El recurso se creo con exito, y se devuelve la ubicacion del recurso creado
                return Results.Created("api/usuario/{usuario.Id}", usuario);
            }).WithTags("Usuario");

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

