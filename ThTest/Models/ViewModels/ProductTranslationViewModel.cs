using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class ProductTranslationViewModel : ViewModelBase
    {
        public string LanguageId
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        public string LanguageName
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredProductName")]
        [MaxLength(40, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthProductName")]
        public string Name
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [MaxLength(4000, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthProductDescription")]
        public string Description
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }
        public ProductTranslationViewModel()
            : base()
        {
        }

    }
}
