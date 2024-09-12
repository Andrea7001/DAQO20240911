namespace DAQO20240911.Endpoints
{
    public static class BodegaEndpoint
    {
        static List<Bodega> bodegas = new List<Bodega>();

        public static void AddBodegaEndpoints(this WebApplication app)
        {
            // Endpoint privado para crear una nueva bodega
            app.MapPost("/bodegas", (BodegaRequest request) =>
            {
                var bodega = new Bodega
                {
                    Id = Guid.NewGuid(), // Asumiendo que el Id es un GUID
                    Nombre = request.Nombre,
                    Ubicacion = request.Ubicacion
                };
                bodegas.Add(bodega);

                return Results.Created($"/bodegas/{bodega.Id}", bodega);
            }).RequireAuthorization();

            // Endpoint privado para modificar una bodega existente
            app.MapPut("/bodegas/{id}", (Guid id, BodegaRequest request) =>
            {
                var bodega = bodegas.FirstOrDefault(b => b.Id == id);
                if (bodega == null) return Results.NotFound();

                bodega.Nombre = request.Nombre;
                bodega.Ubicacion = request.Ubicacion;

                return Results.Ok(bodega);
            }).RequireAuthorization();

            // Endpoint privado para obtener una bodega por Id
            app.MapGet("/bodegas/{id}", (Guid id) =>
            {
                var bodega = bodegas.FirstOrDefault(b => b.Id == id);
                if (bodega == null) return Results.NotFound();

                return Results.Ok(bodega);
            }).RequireAuthorization();

            // Endpoint privado para obtener todas las bodegas
            app.MapGet("/bodegas", () =>
            {
                return Results.Ok(bodegas);
            }).RequireAuthorization();
        }
    }

    public class Bodega
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }

    public class BodegaRequest
    {
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
    }


}
