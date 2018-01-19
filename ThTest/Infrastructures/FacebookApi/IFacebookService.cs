using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Infrastructures.FacebookApi
{
    public interface IFacebookService
    {
        Task<User> GetUserAsync(string accessToken);

        Task PostOnWallAsync(string accessToken, string message);

        Task<string> GetAccessToken(string applicationId, string applicationSecret);
    }
}
