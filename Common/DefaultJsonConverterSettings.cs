using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
namespace Common
{
    public static class DefaultJsonConverterSettings
    {
        public static JsonSerializerSettings Settings => ConfigureSettings(new JsonSerializerSettings());

        public static JsonSerializerSettings ConfigureSettings(JsonSerializerSettings settings)
        {
            settings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
            settings.DateParseHandling = DateParseHandling.None;
            settings.ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
            settings.Converters = new List<JsonConverter>
            {
                new StringEnumConverter()
            };

            return settings;
        }
    }
}
