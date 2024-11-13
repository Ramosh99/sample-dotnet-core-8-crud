using Microsoft.EntityFrameworkCore;
using webappAPI.Models;

namespace webappAPI
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
    }
}
