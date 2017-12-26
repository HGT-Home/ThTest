using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Th.Models
{
    [Table("Roles")]
    public class Role : IdentityRole
    {
        [Column(nameof(Description))]
        public string Description { get; set; }
    }
}
