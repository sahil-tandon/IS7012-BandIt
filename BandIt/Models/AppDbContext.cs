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
        public DbSet<Manager> Manager { get; set; }
        public DbSet<Band> Band { get; set; }

        public DbSet<Concert> Concert { get; set; }
        public DbSet<Song> Song { get; set; }
    }
}