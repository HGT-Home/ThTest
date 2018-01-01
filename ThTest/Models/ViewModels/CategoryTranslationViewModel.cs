using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class CategoryTranslationViewModel: ViewModelBase
    {
        public string LanguageId
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public int CategoryId
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public string LanguageName
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(1024)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequireName")]
        public string Name
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(4000, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EditCategoryViewModelMaxLengthDescription")]
        public string Description
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public CategoryTranslationViewModel()
            : base()
        {

        }
    }
}
