using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Th.Models
{
    public abstract class ThBaseModel
    {
        [NotMapped]
        protected virtual string CurrentCulture { get; set; }

        public ThBaseModel(string strCurrentCulture)
        {
            this.CurrentCulture = strCurrentCulture;
        }

        //public virtual string GetTranslationValue(string strLanguageId = "", [CallerMemberName]string strPropertyName = null)
        //{
        //    if (this.Translations != null && this.Translations.Count > 0)
        //    {
        //        if (string.IsNullOrEmpty(strLanguageId))
        //        {
        //            strLanguageId = Thread.CurrentThread.CurrentCulture.Name;
        //        }

        //        strLanguageId = strLanguageId ?? "en-US"; // Set default value.

        //        ITranslation translation = this.Translations
        //            .FirstOrDefault(t => t.LanguageId == strLanguageId && t.ColumnName == strPropertyName);

        //        if (translation != null)
        //        {
        //            return translation.Value;
        //        }
        //    }

        //    return string.Empty;
        //}

        //public virtual TTranslation CreateTranslation<TTranslation>(string strLanguageId, string strValue, [CallerMemberName]string strPropertyName = null) where TTranslation: ITranslation
        //{
        //    ITranslation translation = (TTranslation)Activator.CreateInstance(typeof(TTranslation));

        //    if (translation != null)
        //    {
        //        return (TTranslation)translation;
        //    }

        //    return default(TTranslation);
        //}

        //protected void AddTranslation<TTranslation>(TTranslation translation) where TTranslation: ITranslation
        //{
        //    this.Translations.Add(translation);
        //}
    }
}
