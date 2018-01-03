using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Customers")]
    public class Customer: ThBaseModel
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [Column(nameof(Address))]
        public string Address { get; set; }

        [Column(nameof(CityId))]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        [MaxLength(128)]
        [Column(nameof(Username))]
        public string Username { get; set; }

        public IList<User> Users { get; set; }

        public Customer()
        {
                
        }
    }
}
