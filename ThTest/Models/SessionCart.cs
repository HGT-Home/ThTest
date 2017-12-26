using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Infrastructures;
using Th.Models;

namespace ThTest.Models
{
    public class SessionCart: Cart
    {
        private const string SESSION_CART_NAME = "Cart";

        [JsonIgnore]
        public ISession Session { get; set; }

        public SessionCart()
            : base()
        {

        }

        public static Cart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart sessionCart = session?.Get<SessionCart>(SESSION_CART_NAME) ?? new SessionCart();
            sessionCart.Session = session;

            return sessionCart;
        }

        public override void AddItem(Product mdProduct, int quantity = 1)
        {
            base.AddItem(mdProduct, quantity);
            this.Session.Set(SESSION_CART_NAME, this);
        }

        public override void RemoveLine(Product mdProduct)
        {
            base.RemoveLine(mdProduct);
            this.Session.Set(SESSION_CART_NAME, this);
        }

        public override void Clear()
        {
            base.Clear();
            this.Session.Remove(SESSION_CART_NAME);
        }
    }
}
