using System.Runtime.Intrinsics.Arm;
using Microsoft.EntityFrameworkCore;
using startModel.Models;

namespace startModel.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
            
        }

        public DbSet<Department> departments { get; set; }


    }
}
