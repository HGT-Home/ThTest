using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Th.Models
{
    public static class LanguageTranslationExtension
    {
        public static string GetLanguageText<T>(this ILanguageTranslation<T> translation, [CallerMemberName]string strPropertyName = null) where T:ITranslation
        {
            if(translation != null && translation.Translations != null && translation.Translations.Count > 0)
            {
                string strLang = Thread.CurrentThread.CurrentCulture.Name;

                ITranslation value = translation.Translations.FirstOrDefault(t => t.LanguageId == strLang && t.ColumnName == strPropertyName);

                if (value != null)
                {
                    return value.Value;
                }
            }

            return string.Empty;
        }
    }
}
