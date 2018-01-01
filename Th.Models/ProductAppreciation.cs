using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    /// <summary>
    /// Đánh giá sản phẩm.
    /// </summary>
    [Table("ProductAppreciateions")]
    public class ProductAppreciation: ThBaseModel
    {
        [Key]
        [Required]
        [Column(nameof(Id))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }

        [Column(nameof(ProductId))]
        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        [Required]
        [Column(nameof(CustomerId))]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Column(nameof(Point))]
        public decimal Point { get; set; }

        [Column(nameof(CreatedDate))]
        public DateTime CreatedDate { get; set; }

        [Column(nameof(UpdatedDate))]
        public DateTime UpdatedDate { get; set; }

        [MaxLength(50)]
        [Column(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [MaxLength(50)]
        [Column(nameof(UpdatedBy))]
        public string UpdatedBy { get; set; }

        public ProductAppreciation()
        {

        }
    }
}
