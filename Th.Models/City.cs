using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Cities")]
    public class City: ThBaseModel
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

        [Column(nameof(CountryId))]
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public Country Country { get; set; }

        public City()
            : base(string.Empty)
        {

        }
    }
}
