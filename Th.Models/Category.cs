using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Categories")]
    public class Category : ThBaseModel
    {
        [Column(nameof(Id))]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(nameof(NameVn))]
        [MaxLength(50)]
        public string NameVn { get; set; }

        [Column(nameof(Name))]
        [MaxLength(50)]
        public string Name { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime? UpdatedDate { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        [Column(nameof(ImagePath))]
        [MaxLength(1024)]
        public string ImagePath { get; set; }

        [Column(nameof(ImageBinary))]
        public byte[] ImageBinary { get; set; }

        [Column(nameof(Description))]
        [MaxLength(4000)]
        public string Description { get; set; }

        public IList<Product> Products { get; set; }

        public Category()
            : base()
        {

        }
    }
}
