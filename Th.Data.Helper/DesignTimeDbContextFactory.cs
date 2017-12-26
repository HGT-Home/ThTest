using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Th.Data.Helper
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ThDbContext>
    {
        public ThDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            DbContextOptionsBuilder dbContextOptionsBuilder = new DbContextOptionsBuilder<ThDbContext>();

            string strConnectionString = configuration.GetConnectionString("DefaultConnection");
            dbContextOptionsBuilder.UseSqlServer(strConnectionString);

            return new ThDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
