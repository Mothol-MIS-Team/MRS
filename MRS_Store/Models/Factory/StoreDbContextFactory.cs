using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
namespace MRS_Store.Models
{
    public class StoreDbContextFactory : IDesignTimeDbContextFactory<StoreDbContext>
    {
        public StoreDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<StoreDbContext>();
            
            options.UseSqlServer("Server=AM1010;Database=StoreData;user=sa;Password=P@ssw0rd;");
            return new StoreDbContext(options.Options);
        }
    }
}
