using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Languages")]
    public class Language: ThBaseModel
    {
        [Key]
        [Required]
        [MaxLength(50)]
        public string LanguageId { get; set; }

        [MaxLength(1024)]
        [Column(nameof(Name))]
        public string Name { get; set; }

        [MaxLength(4000)]
        [Column(nameof(Description))]
        public string Description { get; set; }

        [Column(nameof(IsDefault))]
        public bool IsDefault { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(50)]
        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        public Language()
            : base(string.Empty)
        {

        }
    }
}
