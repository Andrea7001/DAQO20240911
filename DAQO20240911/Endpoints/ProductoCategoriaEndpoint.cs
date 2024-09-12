namespace DAQO20240911.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<CategoriaProducto> categoriaProductos = new List<CategoriaProducto>();

        public static void AddCategoriaProductoEndpoints(this WebApplication app)
        {
             
            app.MapGet("/categoria-productos", () =>
            {
                return categoriaProductos;
            });

             
            app.MapPost("/categoria-productos", (CategoriaProductoRequest request) =>
            {
                
                if (request.Id <= 0)
                {
                    return Results.BadRequest("El Id debe ser un número positivo.");
                }

                var categoriaProducto = new CategoriaProducto
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    Descripcion = request.Descripcion
                };

                categoriaProductos.Add(categoriaProducto);

                return Results.Ok();
            }).RequireAuthorization();
        }
    }

    public class CategoriaProducto
    {
        public int Id { get; set; }    
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

    public class CategoriaProductoRequest
    {
        public int Id { get; set; }  
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }



}
