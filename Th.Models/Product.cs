using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Th.Models
{
    [Table("Products")]
    public class Product : ThBaseModel, ILanguageTranslation<ProductTranslation>
    {
        [Column(nameof(Id))]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Column(nameof(Name))]
        [NotMapped]
        public string Name
        {
            get
            {
                return this.GetLanguageText();
            }
        }

        //[Column(nameof(Description))]
        //[MaxLength(4000, ErrorMessage = "Description is too long. It only {1}.")]
        [NotMapped]
        public string Description
        {
            get
            {
                return this.GetLanguageText();
            }
        }

        [Column(nameof(UnitPrice))]
        [Required(ErrorMessage = "Enter the UnitPrice.")]
        [Range(0, double.MaxValue, ErrorMessage = "UnitPrice value is invalid. It is from {1} to {2}.")]
        public decimal UnitPrice { get; set; }

        [Column(nameof(ImagePath))]
        [MaxLength(1024)]
        //[Required(ErrorMessage = "Enter the Image.")]
        public string ImagePath { get; set; }

        [Column(nameof(ImageBinary))]
        public byte[] ImageBinary { get; set; }

        [Column(nameof(CategoryId))]
        [Required(ErrorMessage = "Enter the Category.")]
        [DefaultValue(null)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Column(nameof(SupplierId))]
        [MaxLength(50, ErrorMessage = "Supplier id is too long. It only {1}.")]
        [Required(ErrorMessage = "Enter the Supplier.")]
        public string SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Suppiler { get; set; }

        [Column(nameof(UpdatedBy))]
        [MaxLength(50)]
        public string UpdatedBy { get; set; }

        [Column(nameof(CreatedBy))]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime? UpdatedDate { get; set; }

        [Column(nameof(ViewCount))]
        public int ViewCount { get; set; }

        public IList<ProductTranslation> Translations { get; set; }
        
        public Product()
            : base("")
        {
            
        }

        public Product(string strCulture)
            : base(strCulture)
        {
            
        }
    }
}
