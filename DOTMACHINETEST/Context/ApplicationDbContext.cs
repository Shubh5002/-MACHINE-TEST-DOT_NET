using DOTMACHINETEST.Models;
using Microsoft.EntityFrameworkCore;

namespace DOTMACHINETEST.Context
{
    // ApplicationDbContext
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }

}
