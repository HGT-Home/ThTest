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
            get
            {
                return this.GetValue<int>();
            }
            set
            {
                this.SetValue(value);
            }
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequireNameVn")]
        [MaxLength(50)]
        public string NameVn
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [MaxLength(50)]
        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequireName")]
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

        public EditCategoryViewModel()
            : base()
        {

        }
    }
}
