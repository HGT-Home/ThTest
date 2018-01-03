using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Companies")]
    public class Company: ThBaseModel
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [MaxLength(256)]
        [Column(nameof(Name))]
        public string Name { get; set; }

        [MaxLength(1024)]
        [Column(nameof(Address))]
        public string Address { get; set; }

        [Column(nameof(Latitude))]
        public string Latitude { get; set; }

        [Column(nameof(Longitude))]
        public string Longitude { get; set; }

        [Column(nameof(IsDefault))]
        public bool IsDefault { get; set; }

        [MaxLength(50)]
        [Column(nameof(Phone))]
        public string Phone { get; set; }

        [MaxLength(50)]
        [Column(nameof(Hotline))]
        public string Hotline { get; set; }

        [MaxLength(256)]
        [Column(nameof(Email))]
        public string Email { get; set; }

        [MaxLength(1024)]
        [Column(nameof(Facebook))]
        public string Facebook { get; set; }

        [MaxLength(1024)]
        [Column(nameof(Twitter))]
        public string Twitter { get; set; }

        public Company()
            : base()
        {
            // 9.609545, 105.97213
            //this.Latitude = "9.609545";
            //this.Latitude = "105.97213";
        }
    }
}
