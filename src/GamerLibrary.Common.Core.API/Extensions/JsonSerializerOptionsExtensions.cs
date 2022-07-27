using System.Text.Json;
using System.Text.Json.Serialization;

namespace GamerLibrary.Common.Core.API.Extensions
{
    public static class JsonSerializerOptionsExtensions
    {
        /// <summary>
        /// Set the default configuration for <paramref name="options"/> to each services
        /// </summary>
        /// <param name="options"></param>
        /// <returns>Default configurations</returns>
        public static JsonSerializerOptions SetSerializeOptions(this JsonSerializerOptions options)
        {
            options.PropertyNameCaseInsensitive = true;
            options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            return options;
        }
    }
}
