using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Models
{
    public interface ILanguageTranslation<T> where T: ITranslation
    {
        IList<T> Translations { get; }
    }
}
