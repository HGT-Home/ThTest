using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Categories")]
    public class Category : ThBaseModel, ILanguageTranslation<CategoryTranslation>
    {
        [Column(nameof(Id))]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //[Column(nameof(Name))]
        [NotMapped]
        [MaxLength(1024)]
        public string Name
        {
            get
            {
                return this.GetLanguageText();
            }
        }

        //[Column(nameof(Description))]
        [NotMapped]
        [MaxLength(4000)]
        public string Description
        {
            get
            {
                return this.GetLanguageText();
            }
                
        }

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

        public IList<Product> Products { get; set; }

        public IList<CategoryTranslation> Translations { get; set; }

        public Category()
        {

        }
    }
}
