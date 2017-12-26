using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ThTest.Models.ViewModels
{
    public enum ThAction
    {
        None = 0,
        Add = 1,
        Edit = 2,
        Delete  = 4,
    }

    public abstract class ViewModelBase
    {
        [EnumDataType(typeof(ThAction))]
        public ThAction? Mode { get; set; } = ThAction.None;

        private Dictionary<string, object> Values { get; set; } = new Dictionary<string, object>();

        protected T GetValue<T>([CallerMemberName] string strPropertyName = null)
        {
            if (this.Values.ContainsKey(strPropertyName))
            {
                return (T)this.Values[strPropertyName];
            }

            return default(T);
        }

        protected void SetValue(object value, [CallerMemberName]string strPropertyName = null)
        {
            if (!string.IsNullOrEmpty(strPropertyName))
            {
                this.Values[strPropertyName] = value;

            }
        }

        public ViewModelBase()
        {
        }
    }
}
