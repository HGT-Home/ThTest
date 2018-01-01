using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("ProductTranslations")]
    public class ProductTranslation: ThBaseModel, ITranslation
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(nameof(ProductId))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(nameof(LanguageId))]
        public string LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }

        [MaxLength(50)]
        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime UpdatedDate { get; set; }

        public string ColumnName { get; set; }

        [Column(nameof(Value))]
        public string Value { get; set; }

        public ProductTranslation()
        {
        }
    }
}
