using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class EditSupplierViewModel : ViewModelBase
    {
        public string Id
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredSupplierName")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthSupplierName")]
        public string Name
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredSupplierEmail")]
        [MaxLength(255, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthSupplerEmail")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$|^\+?\d{0,2}\-?\d{4,5}\-?\d{5,6}", ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "EmailInvalid")]
        public string Email
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(50, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthPhone")]
        public string Phone
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }

        [MaxLength(1024, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthAddress")]
        public string Address
        {
            get => this.GetValue<string>();
            set => this.SetValue(value);
        }
    }
}
