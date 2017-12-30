using System;
using System.Collections.Generic;
using System.Text;

namespace Th.Models
{
    /// <summary>
    /// Hổ trợ đa ngôn ngữ trong database.
    /// </summary>
    public interface ITranslation 
    {
        string LanguageId { get; set; }

        string ColumnName { get; set; }

        string Value { get; set; }
    }
}
