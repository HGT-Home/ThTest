using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThTest.Infrastructures
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            JsonSerializerSettings jsonSetting = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            session.SetString(key, JsonConvert.SerializeObject(value, jsonSetting));
        }

        public static T Get<T>(this ISession session, string key)
        {
            string value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
