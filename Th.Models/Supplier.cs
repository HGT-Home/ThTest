using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Suppliers")]
    public class Supplier : ThBaseModel
    {
        [Column(nameof(Id))]
        [Required]
        [Key]
        [MaxLength(50)]
        public string Id { get; set; }

        [Column(nameof(Name))]
        [MaxLength(1024)]
        public string Name { get; set; }

        [Column(nameof(Logo))]
        [MaxLength(1024)]
        public string Logo { get; set; }

        [Column(nameof(Email))]
        [MaxLength(1024)]
        public string Email { get; set; }

        [Column(nameof(Phone))]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Column(nameof(Address))]
        [MaxLength(1024)]
        public string Address { get; set; }

        public IList<Product> Products { get; set; }

        public Supplier()
        {

        }
    }
}
