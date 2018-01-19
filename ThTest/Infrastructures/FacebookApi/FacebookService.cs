using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Infrastructures.FacebookApi
{
    public class FacebookService : IFacebookService
    {
        private readonly IFacebookClient _facebookClient;

        public FacebookService(IFacebookClient facebookClient)
        {
            this._facebookClient = facebookClient;
        }

        public async Task<User> GetUserAsync(string accessToken)
        {
            try
            {
                // fields=id,name,email,first_name,last_name,age_range,birthday,gender,locale
                var result = await this._facebookClient.GetAsync<dynamic>(accessToken, "oauth/accounts");

                if (result != null)
                {
                    return new User
                    {
                        Id = result.Id,
                        Email = result.email,
                        Name = result.name,
                        UserName = result.username,
                        FirstName = result.first_name,
                        LastName = result.last_name,
                        Locale = result.locale
                    };
                }

                return new User();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostOnWallAsync(string accessToken, string message)
        {
            try
            {
                await this._facebookClient.PostAsync(accessToken, "me/feed", new { message });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetAccessToken(string applicationId, string applicationSecret)
        {
            try
            {
                return await this._facebookClient.GetAccessToken(applicationId, applicationSecret);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
