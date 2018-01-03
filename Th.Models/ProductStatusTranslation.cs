using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    public class ProductStatusTranslation : ThBaseModel, ITranslation
    {
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(LanguageId))]
        [MaxLength(50)]
        public string LanguageId
        {
            get;
            set;
        }

        [Column(nameof(ColumnName))]
        [MaxLength(128)]
        public string ColumnName
        {
            get;
            set;
        }

        [Column(nameof(Value))]
        public string Value
        {
            get;
            set;
        }

        [Column(nameof(ProductStatusId))]
        public int ProductStatusId { get; set; }

        [ForeignKey(nameof(ProductStatusId))]
        public ProductStatus ProductStatus { get; set; }
    }
}
