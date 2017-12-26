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

        //private string _userId;
        public string UserId { get; set; }
        //{
        //    get
        //    {
        //        return this._userId;
        //    }
        //    set
        //    {
        //        this._userId = value;

        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}

        //private string _username;
        public string Username { get; set; }
        //{
        //    get
        //    {
        //        return this._username;
        //    }
        //    set
        //    {
        //        this._username = value;

        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}


        //private int? _customerId;
        public int? CustomerId { get; set; }
        //{
        //    get
        //    {
        //        return this._customerId;
        //    }
        //    set
        //    {
        //        this._customerId = value;
        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}

        //private string _customerName;
        
        public string CustomerName { get; set; }
        //{
        //    get
        //    {
        //        return this._customerName;
        //    }
        //    set
        //    {
        //        this._customerName = value;
        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}

        //private DateTime _loginDate;
        public DateTime LoginDate { get; set; }
        //{
        //    get
        //    {
        //        return this._loginDate;
        //    }
        //    set
        //    {
        //        this._loginDate = value;
        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}

        //private string _roleNames;
        public string RoleNames { get; set; }
        //{
        //    get
        //    {
        //        return this._roleNames;
        //    }

        //    set
        //    {
        //        this._roleNames = value;
        //        this.Session.Set(SESSION_LOGIN_INFO_NAME, this);
        //    }
        //}

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
