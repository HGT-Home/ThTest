using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("CategoryTranslations")]
    public class CategoryTranslation : ThBaseModel, ITranslation
    {
        [Key, Required]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(CategoryId))]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }

        [Required]
        [Column(nameof(LanguageId))]
        public string LanguageId { get; set; }

        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }

        [Column(nameof(ColumnName))]
        public string ColumnName { get; set; }

        [Column(nameof(Value))]
        public string Value { get; set; }

        public CategoryTranslation()
            : base()
        {

        }
    }
}
