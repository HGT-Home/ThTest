using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Countries")]
    public class Country : ThBaseModel
    {
        [Column(nameof(Id))]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(nameof(Name))]
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        public IList<City> Cities { get; set; }

        public Country()
            : base()
        {
            this.Cities = new List<City>();
        }
    }
}
