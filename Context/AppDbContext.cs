using Microsoft.EntityFrameworkCore;
using Ticketback.Models;

namespace Ticketback.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Etat> Etats { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Activities> Activites { get; set; }
        public DbSet<Groups> Groupss { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }

        internal object GetSection(string v)
        {
            throw new NotImplementedException();
        }
    }
}
