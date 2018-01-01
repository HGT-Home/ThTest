using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class EditCategoryViewModel: ViewModelBase
    {
        [Required]
        public int Id
        {
            get => this.GetValue<int>();
            set => this.SetValue(value);
        }

        public string Name
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public IFormFile FileImage
        {
            get => this.GetValue<IFormFile>();
            set => this.SetValue(value);
        }

        [MaxLength(1024)]
        public string ImagePath
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public byte[] ImageBinary
        {
            get => this.GetValue<byte[]>();
            set => this.SetValue(value);
        }

        [MaxLength(4000, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EditCategoryViewModelMaxLengthDescription")]
        public string Description
        {
            get =>  this.GetValue<string>();
            set => this.SetValue(value);
        }

        public string CreatedBy
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public string UpdatedBy
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        public DateTime? UpdatedDate
        {
            get => this.GetValue<DateTime?>();
            set => this.SetValue(value);
        }

        public DateTime? CreatedDate
        {
            get => this.GetValue<DateTime?>();
            set => this.SetValue(value);
        }

        public IList<CategoryTranslationViewModel> Translations { get; set; }

        public EditCategoryViewModel()
            : base()
        {

        }
    }
}
