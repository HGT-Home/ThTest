using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("ProductStatuses")]
    public class ProductStatus: ThBaseModel, ILanguageTranslation<ProductStatusTranslation>
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [NotMapped]
        public string Name
        {
            get
            {
                return this.GetLanguageText();
            }
        }

        [NotMapped]
        public string Description
        {
            get
            {
                return this.GetLanguageText();
            }
        }

        [Column(nameof(IsStop))]
        public bool IsStop { get; set; }

        [MaxLength(50)]
        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [MaxLength(50)]
        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime UpdatedDate { get; set; }

        public IList<ProductStatusTranslation> Translations { get; set; }

        public IList<Product> Products { get; set; }

        public ProductStatus()
            : base()
        {

        }
    }
}
