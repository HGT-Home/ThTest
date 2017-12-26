using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Th.Models
{
    [Table("Products")]
    public class Product : ThBaseModel
    {
        [Column(nameof(Id))]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(nameof(Name))]
        [Required(ErrorMessage = "Enter the Name.")]
        [MaxLength(40, ErrorMessage = "Name is too long. It only {1}.")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Column(nameof(UnitPrice))]
        [Required(ErrorMessage = "Enter the UnitPrice.")]
        [Range(0, double.MaxValue, ErrorMessage = "UnitPrice value is invalid. It is from {1} to {2}.")]
        public decimal UnitPrice { get; set; }

        [Column(nameof(Image))]
        [MaxLength(50)]
        //[Required(ErrorMessage = "Enter the Image.")]
        public string Image { get; set; }

        [Column(nameof(Description))]
        [MaxLength(2000, ErrorMessage = "Description is too long. It only {1}.")]
        public string Description { get; set; }

        [Column(nameof(CategoryId))]
        [Required(ErrorMessage = "Enter the Category.")]
        [DefaultValue(null)]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Column(nameof(SupplierId))]
        [MaxLength(50, ErrorMessage = "Supplier id is too long. It only {1}.")]
        [Required(ErrorMessage = "Enter the Supplier.")]
        public string SupplierId { get; set; }

        [ForeignKey(nameof(SupplierId))]
        public Supplier Suppiler { get; set; }

    }
}
