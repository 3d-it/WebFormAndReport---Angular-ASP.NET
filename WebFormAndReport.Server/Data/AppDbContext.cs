using Microsoft.EntityFrameworkCore;
using WebFormAndReport.Server.Models;

namespace WebFormAndReport.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
