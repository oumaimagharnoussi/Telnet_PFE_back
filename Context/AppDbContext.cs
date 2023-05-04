using Microsoft.EntityFrameworkCore;
using Ticketback.Models;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Claims;

namespace Ticketback.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Etat> Etats { get; set; }
        public DbSet<Telnet> Telnet { get; set; }
        public DbSet<Commentaire> Commentaires { get; set; }
        public DbSet<Activitie> Activities { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
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
              .HasOne(u => u.Groupe)
              .WithMany(g => g.Users)
              .HasForeignKey(u => u.groupId);

             modelBuilder.Entity<User>()
                             .HasOne(u => u.Telnet)
                             .WithMany(s => s.Users)
                             .HasForeignKey(u => u.telnetId);

             modelBuilder.Entity<Telnet>()
            .HasMany(s => s.Users)
            .WithOne(u => u.Telnet)
            .HasForeignKey(u => u.telnetId);

            modelBuilder.Entity<Telnet>()
            .HasMany(s => s.Ticket)
            .WithOne(u => u.Telnet)
            .HasForeignKey(u => u.telnetId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Ticket)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Commentaire)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
        .ToTable("Tickets")
        .HasKey(t => t.ticketId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Ticket)
                .HasForeignKey(t => t.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
     .HasOne(t => t.Telnet)
     .WithMany(a => a.Ticket)
     .HasForeignKey(t => t.telnetId)
     .HasPrincipalKey(a => a.telnetId)
     .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Ticket>()
         .HasOne(t => t.Etat)
         .WithMany()
         .HasForeignKey(t => t.id)
         .OnDelete(DeleteBehavior.Restrict);
            // set the default value for Etat.id to 1
            modelBuilder.Entity<Etat>()
                .Property(e => e.id)
                .HasDefaultValue(1);
            // set the default value for Ticket.id to 1
            modelBuilder.Entity<Ticket>()
                .Property(t => t.id)
                .HasDefaultValue(1);

            /* modelBuilder.Entity<Ticket>()
                 .HasOne(t => t.PrisEnChargePar)
                 .WithMany()
                 .HasForeignKey(t => t.prisEnChargePar)
                 .OnDelete(DeleteBehavior.Restrict);*/

            // Configure the Commentaire entity
            modelBuilder.Entity<Commentaire>()
                .ToTable("Commentaires")
                .HasKey(c => c.commentaireId);

            modelBuilder.Entity<Commentaire>()
                .HasOne(c => c.User)
                .WithMany(u => u.Commentaire)
                .HasForeignKey(c => c.userId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Commentaire>()
               .HasOne(c => c.Ticket)
               .WithMany(u => u.Commentaire)
               .HasForeignKey(c => c.ticketId)
               .OnDelete(DeleteBehavior.Restrict);

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

        internal Task ChangePasswordAsync(object user, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        internal Task FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        internal object GetSection(string v)
        {
            throw new NotImplementedException();
        }

        internal Task GetUserAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
