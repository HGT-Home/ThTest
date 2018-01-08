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

        [Column(nameof(CityId))]
        public int CityId { get; set; }

        [Column(nameof(CountryId))]
        public int CountryId { get; set; }

        [MaxLength(50)]
        [Column(nameof(Fax))]
        public string Fax { get; set; }

        [MaxLength(256)]
        [Column(nameof(WebSiste))]
        public string WebSiste { get; set; }

        [MaxLength(50)]
        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime? CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime? UpdatedDate { get; set; }

        public IList<Product> Products { get; set; }

        public Supplier()
            : base()
        {

        }
    }
}
