namespace DAQO20240911.Endpoints
{
    public static class CategoriaProductoEndpoint
    {
        static List<CategoriaProducto> categoriaProductos = new List<CategoriaProducto>();

        public static void AddCategoriaProductoEndpoints(this WebApplication app)
        {
            // Endpoint público para obtener todos los registros
            app.MapGet("/categoria-productos", () =>
            {
                return categoriaProductos;
            });

            // Endpoint privado para registrar nuevos registros
            app.MapPost("/categoria-productos", (CategoriaProductoRequest request) =>
            {
                var categoriaProducto = new CategoriaProducto
                {
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
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }

    public class CategoriaProductoRequest
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }


}
