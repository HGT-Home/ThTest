using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("OrderDetails")]
    public class OrderDetail: ThBaseModel
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(OrderDetailId))]
        public int OrderDetailId { get; set; }

        [Required]
        [Column(nameof(OrderId))]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        [Required]
        [Column(nameof(ProductId))]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Column(nameof(Quantity))]
        public decimal Quantity { get; set; }

        [Column(nameof(Price))]
        public decimal Price { get; set; }

        [Column(nameof(SubTotal))]
        public decimal SubTotal { get; set; }

        public OrderDetail()
            : base(string.Empty)
        {

        }
    }
}
