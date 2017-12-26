using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Th.Models;

namespace ThTest.Models.Helpers
{
    public static class UserHelper
    {
        public static void CreateAdministratorUser(this User user)
        {

            //user.UserName = "Admin";
            //user.Email = "admin@gmail.com";
            //user.FullName = "Administrator";
            //user.DateOfBirth = DateTime.Now;

            //Role roleAdmin = new Role
            //{
            //    Name = "Administrators",
            //    Description = "Administrator group."
            //};

            //RoleManager<Role> roleManager = new RoleManager<Role>();

            //IdentityResult roleCreateResult = await this._roleMananger.CreateAsync(roleAdmin);

            //IdentityResult userAdminResult = await this._userManager.CreateAsync(adminUser, "Administrator10");
            //if (userAdminResult.Succeeded)
            //{
            //    await this._userManager.AddToRoleAsync(adminUser, "Administrators");
            //}
        }
    }
}
