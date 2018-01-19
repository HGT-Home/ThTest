using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Users")]
    public class User : IdentityUser
    {
        [MaxLength(128)]
        [Column(nameof(FirstName))]
        public string FirstName { get; set; }

        [MaxLength(128)]
        [Column(nameof(LastName))]
        public string LastName { get; set; }

        [MaxLength(256)]
        [Column(nameof(FullName))]
        public string FullName { get; set; }

        [Column(nameof(DateOfBirth))]
        public DateTime DateOfBirth { get; set; }

        [Column(nameof(CustomerId))]
        public int? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [Column(nameof(EmployeeId))]
        public int? EmployeeId { get; set; }

        [MaxLength(128)]
        [Column(nameof(Name))]
        public string Name { get; set; }

        [MaxLength(128)]
        [Column(nameof(Locale))]
        public string Locale { get; set; }

        [MaxLength(64)]
        [Column(nameof(Gender))]
        public string Gender { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();

        public User()
            : base(string.Empty)
        {

        }

        public User(string strUsername)
            : base(strUsername)
        {
        }
    }
}
