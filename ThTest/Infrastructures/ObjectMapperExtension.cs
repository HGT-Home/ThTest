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

                // Dùng để serialize các IList<T> con trong đối đươc source
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            string jsonString = JsonConvert.SerializeObject(source, jsonSetting);

            TDestination destination = JsonConvert.DeserializeObject<TDestination>(jsonString);

            return destination;
        }
    }
}
