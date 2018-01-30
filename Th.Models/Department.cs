using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Departments")]
    public class Department: ThBaseModel
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(nameof(Id))]
        public int Id { get; set; }

        [MaxLength(256)]
        [Required]
        [Column(nameof(Name))]
        public string Name { get; set; }

        [MaxLength(4000)]
        [Column(nameof(Description))]
        public string Description { get; set; }

        public IList<Employee> Employees { get; set; }

        public Department()
            : base()
        {

        }
    }
}
