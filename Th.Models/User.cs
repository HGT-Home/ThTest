using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        [Column(nameof(FirstName))]
        public string FirstName { get; set; }

        [Column(nameof(LastName))]
        public string LastName { get; set; }

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
