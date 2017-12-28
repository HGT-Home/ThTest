using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public static class ObjectMapperExtension
    {
        public static TDestination Map<TDestination>(this object source)
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };

            string jsonString = JsonConvert.SerializeObject(source, jsonSetting);

            TDestination destination = JsonConvert.DeserializeObject<TDestination>(jsonString);

            return destination;
        }
    }
}
