    using RestauranteAPI.DTOs;
    using RestauranteAPI.Entities;
    using RestauranteAPI.Repositories.Interfaces;

    namespace RestauranteAPI.Endpoints
    {
        public static class ProductoEndpoints
        {
            //DEVUELVE TODOS
            public static void Add(this WebApplication app)
            {
            app.MapGet("api/productos", /*[Authorize]*/ async (IProducto _producto) =>
            {
                var productos = await _producto.Productos();
                //200 OK - Muestra que la solicitud se realizo correctamente
                //y se devuelve una vista
                return Results.Ok(productos);
            }).WithTags("Producto"); //Visible metodo listar sin autorizacion

            //OBTENER POR ID [Authorize] sustituye a : RequireAuthorization();
                app.MapGet("api/productos/{id}",/*[Authorize]*/  async (int id, IProducto _producto) =>
                {
                    var producto = await _producto.Producto(id);
                    if (producto == null)
                        return Results.NotFound(); // 404 Not Found -Recurso solicitado no existe
                    else
                        return Results.Ok(producto);////200 OK - Muestra que la solicitud se realizo correctamente
                                                    //y se devuelve una vista
                }).WithTags("Producto").RequireAuthorization(); //.RequireAuthorization();Requiere autorizacion

            //GUARDAR
            app.MapPost("api/producto", async (ProductoDTO producto, IProducto _producto) =>
                {

                    if (producto == null)
                        return Results.BadRequest(); //400 - Bad Request -No se pudo procesar la solicitud
                                                     // Error de formato
                    await _producto.Crear(producto);
                    //200 Created - Recurso creado exitosamente y se devuelve la ubicacion del recurso creado
                    return Results.Created("api/productos/{producto.Id}", producto);
                }).WithTags("Producto").RequireAuthorization();//.RequireAuthorization();Requiere autorizacion

            //MODIFICAR
            app.MapPut("api/producto/{id}", async (int id, ProductoDTO producto, IProducto _producto) =>
                {
                    var resultado = await _producto.Modificar(id, producto);
                    if (resultado == 0)
                        return Results.NotFound(); //404 Not Found -Recurso solicitado no existe
                    else
                        return Results.Ok(resultado); //200 OK - La solicitud se realizo correctamente
                }).WithTags("Producto").RequireAuthorization();//.RequireAuthorization();Requiere autorizacion 

            //ELIMINAR
            app.MapDelete("api/producto/{id}", async (int id, IProducto _producto) =>
                {
                    var resultado = await _producto.Eliminar(id);
                    if (resultado == 0)
                        return Results.NotFound(); //404 Not Found - El recurso soliciado no existe
                    else
                        return Results.NoContent();// 204 No Content - Recurso eliminado
                }).WithTags("Producto").RequireAuthorization();//.RequireAuthorization();Requiere autorizacion
        }
        }
    }
