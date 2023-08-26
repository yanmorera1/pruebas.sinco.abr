using Sinco.Prueba.Colegio.Application.Exceptions;
using System.Text.Json;

namespace Sinco.Prueba.Colegio.Application.Extensions
{
    public static class Json
    {
        public static string ToJson(this object obj)
            => JsonSerializer.Serialize(obj);

        public static T FromJson<T>(this string json)
        {
            if (!string.IsNullOrEmpty(json))
                return JsonSerializer.Deserialize<T>(json);
            else
                throw new InternalServerErrorException("Cannot serialize json string");
        }
    }
}
