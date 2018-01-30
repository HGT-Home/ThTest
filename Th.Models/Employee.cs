using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Employees")]
    public class Employee: ThBaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [MaxLength(1024)]
        [Column(nameof(Address))]
        public string Address { get; set; }

        [MaxLength(16)]
        [Column(nameof(CardIdNumber))]
        public string CardIdNumber { get; set; }

        [MaxLength(16)]
        [Column(nameof(PhoneNumber))]
        public string PhoneNumber { get; set; }

        [MaxLength(256)]
        [Column(nameof(ImagesPath))]
        public string ImagesPath { get; set; }

        [Column(nameof(ImageBinary))]
        public byte[] ImageBinary { get; set; }

        [Column(nameof(DepartmentId))]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public Department Department { get; set; }

        public Employee()
            : base()
        {

        }
    }
}
