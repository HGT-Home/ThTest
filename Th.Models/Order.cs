using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Orders")]
    public class Order: ThBaseModel
    {
        [Column(nameof(OrderId))]
        [Required, Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Column(nameof(OrderDate))]
        public DateTime OrderDate { get; set; }

        [Column(nameof(UserId))]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [Column(nameof(ShipAddress))]
        public string ShipAddress { get; set; }

        [Column(nameof(CityId))]
        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }

        [Column(nameof(IsShipped))]
        public bool IsShipped { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public Order()
            : base()
        {

        }
    }
}
