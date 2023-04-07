using Microsoft.EntityFrameworkCore;
using Ticketback.Models;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata;

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
        public DbSet<Activitie> Activities { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<WorkFromHomeRequest> WorkFromHomeRequests { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
       .ToTable("users")
       .HasMany(u => u.WorkFromHomeRequests)
       
       .WithOne(w => w.User)
       .HasForeignKey(w => w.userId)
       .OnDelete(DeleteBehavior.Cascade)
       .HasConstraintName("FK_WorkFromHomeRequests_Users");


          //  modelBuilder.Entity<User>()
              //  .Property(u => u.groupId)
              //  .HasConversion<int>();
            modelBuilder.Entity<WorkFromHomeRequest>()
                .HasOne(w => w.User)
                .WithMany(u => u.WorkFromHomeRequests)
                .HasForeignKey(w => w.userId)
                .OnDelete(DeleteBehavior.Cascade);

          
            modelBuilder.Entity<User>()
                .HasOne(u => u.Activitie)
                .WithMany(a => a.Users)
                .HasForeignKey(u => u.activityId);

            modelBuilder.Entity<User>()
             .HasOne<Groupe>(u => u.Groupe)
             .WithMany(g => g.Users)
             .HasForeignKey(u => u.groupId);



            // Add indexes to WorkFromHomeRequest entity
            modelBuilder.Entity<WorkFromHomeRequest>()
                .HasIndex(w => new { w.userId, w.startDate, w.endDate })
                .IsUnique();

            // Set default values for WorkFromHomeRequest entity
            modelBuilder.Entity<WorkFromHomeRequest>()
                .Property(w => w.state)
                .HasDefaultValue(Status.InProgress);

            modelBuilder.Entity<WorkFromHomeRequest>()
                .Property(w => w.dayNumber)
                .HasDefaultValue(1);

            modelBuilder.Entity<WorkFromHomeRequest>()
                .Property(w => w.halfDay)
                .HasDefaultValue(HalfDay.Morning);
        }

        internal object GetSection(string v)
        {
            throw new NotImplementedException();
        }
    }
}
