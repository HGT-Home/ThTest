using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Infrastructures;

namespace ThTest.Models
{
    [JsonObject(MemberSerialization = MemberSerialization.OptOut)]
    public class LoginSessionInfo
    {
        private const string SESSION_LOGIN_INFO_NAME = "LoginSessionInfo";

        [JsonIgnore]
        public ISession Session { get; set; }

        public string UserId { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public int? CustomerId { get; set; }

        public string CustomerName { get; set; }
       
        public DateTime LoginDate { get; set; }
       
        public IList<string> RoleNames { get; set; }

        public string CurrentLanguage { get; set; }
       
        public LoginSessionInfo()
        {

        }

        public static LoginSessionInfo GetLoginSessionInfo(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            LoginSessionInfo loginSessionInfo = session?.Get<LoginSessionInfo>(SESSION_LOGIN_INFO_NAME) ?? new LoginSessionInfo();
            loginSessionInfo.Session = session;

            return loginSessionInfo;
        }

        public void SaveSession()
        {
            this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        }

        public void Clear()
        {
            this.Session.Remove(SESSION_LOGIN_INFO_NAME);
        }
    }
}
