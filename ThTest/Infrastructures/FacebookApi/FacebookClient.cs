using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ThTest.Infrastructures.FacebookApi
{
    public class FacebookClient : IFacebookClient
    {
        private readonly HttpClient _httpClient;

        private readonly string MediaType = "application/json";

        public FacebookClient()
        {
            this._httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://graph.facebook.com/"),
            };

            this._httpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue(this.MediaType));
        }

        public async Task<T> GetAsync<T>(string accessToken, string endpoint, string args = null)
        {
            StringBuilder requestUrl = new StringBuilder($"{endpoint}?access_token={accessToken}");

            if (!string.IsNullOrEmpty(args))
            {
                requestUrl.Append($"&{args}");
            }

            var response = await this._httpClient.GetAsync(requestUrl.ToString());

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }

            return default(T);
        }

        public async Task PostAsync(string accessToken, string endpoint, object data, string args = null)
        {
            StringContent payload = this.GetPayload(data);
            StringBuilder requestUrl = new StringBuilder($"{endpoint}?access_token={accessToken}");

            if (args != null)
            {
                requestUrl.Append($"&{args}");
            }

            await this._httpClient.PostAsync(requestUrl.ToString(), payload);
        }

        public async Task<string> GetAccessToken(string applicationId, string applicationSecret)
        {
            try
            {
                var response = await this._httpClient.GetAsync($"https://graph.facebook.com/oauth/access_token?client_id={applicationId}&client_secret={applicationSecret}&grant_type=client_credentials");

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    dynamic obj = JsonConvert.DeserializeObject(result.ToString());
                    
                    return obj.access_token;
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected StringContent GetPayload(object data)
        {
            var json = JsonConvert.SerializeObject(data);

            return new StringContent(json, Encoding.UTF8, this.MediaType);
        }
    }
}
