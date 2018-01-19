using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Th.Models;

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
            if (this.Values.ContainsKey(strPropertyName) && this.Values[strPropertyName] != null)
            {
                return (T)this.Values[strPropertyName];
            }

            return default(T);
        }

        protected void SetValue(object value, [CallerMemberName]string strPropertyName = null)
        {
            if (!string.IsNullOrEmpty(strPropertyName))
            {
                switch (value)
                {
                    case string strValue:
                        value = strValue.Trim();
                        break;
                }

                this.Values[strPropertyName] = value;
            }
        }

        public virtual IList<Language> SupportLanguages
        {
            get => this.GetValue<IList<Language>>();
            set => this.SetValue(value);
        }

        public virtual string CurrentLanguage
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public virtual string ReturnUrl
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public ViewModelBase()
        {
            this.CurrentLanguage = Thread.CurrentThread.CurrentCulture.Name;
        }
    }
}
