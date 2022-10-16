using EcomAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace EcomAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
    }
}
