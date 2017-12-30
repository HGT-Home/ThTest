﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;
using ThTest.Resources;

namespace ThTest.Models.ViewModels
{
    public class EditProductViewModel : ViewModelBase, ILanguageTranslation<ProductTranslation>
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredProductName")]
        [MaxLength(40, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthProductName")]
        [Display(Name = "Product Name")]
        public string Name
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredUnitPrice")]
        [Range(0, double.MaxValue, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RangeUnitPrice")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice
        {
            get => this.GetValue<decimal>();

            set => this.SetValue(value);
        }

        [MaxLength(2000, ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "MaxLengthProductDescription")]
        public string Description
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredCategory")]
        [DefaultValue(null)]
        public int? CategoryId
        {
            get => this.GetValue<int?>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredSupplier")]
        public string SupplierId
        {
            get => this.GetValue<string>();

            set => this.SetValue(value);
        }

        [Required(ErrorMessageResourceType = typeof(ShareResource), ErrorMessageResourceName = "RequiredImage")]
        public IFormFile FileImage
        {
            get => this.GetValue<IFormFile>();

            set => this.SetValue(value);
        }

        public IList<Supplier> Suppliers
        {
            get => this.GetValue<IList<Supplier>>();

            set => this.SetValue(value);
        }

        public IList<Category> Categories
        {
            get => this.GetValue<IList<Category>>();

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

        public string ImagePath
        {
            get
            {
                string value = this.GetValue<string>();

                if (string.IsNullOrEmpty(value))
                {
                    return "imgs/no-image.png";
                }

                return value;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = "imgs/no-image.png";
                }

                this.SetValue(value);
            }
        }

        public int ViewCount
        {
            get => this.GetValue<int>();

            set => this.SetValue(value);
        }

        public IList<ProductTranslation> Translations { get; set; }

        public IList<Language> SupportLanguages { get; set; }
    }
}
