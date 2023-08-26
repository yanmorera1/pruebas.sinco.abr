using Microsoft.Extensions.Logging;
using Sinco.Prueba.Colegio.Domain.Common;
using System.Text.Json;

namespace Sinco.Prueba.Colegio.Infrastructure.Persistence
{
    public class ColegioDbContextSeed
    {
        public static async Task LoadDataAsync(ColegioDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                //if (!context.VehicleTypes!.Any())
                //{
                //    await InsertDefaultData<VehicleType>(context, @"..\Sinco.Prueba.Concesionario.Yan.Morera.Infrastructure\Data\vehicleTypes.json");
                //}
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ColegioDbContextSeed>();
                logger.LogError(ex.Message);
            }
        }
        private static async Task InsertDefaultData<T>(ColegioDbContext context, string path) where T : Entity
        {
            var fileData = File.ReadAllText(path);
            var data = JsonSerializer.Deserialize<List<T>>(fileData);
            context.Set<T>().AddRange(data!);
            await context.SaveChangesAsync();
        }
    }
}
