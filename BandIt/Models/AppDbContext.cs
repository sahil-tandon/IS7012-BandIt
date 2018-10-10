using Microsoft.EntityFrameworkCore;
using BandIt.Models;

namespace BandIt.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
        {
        }
        public DbSet<Band> Band { get; set; }
        public DbSet<Manager> Manager { get; set; }
    }
}