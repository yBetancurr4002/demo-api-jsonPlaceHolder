using Microsoft.EntityFrameworkCore;
using todo_app_server.Models;

namespace todo_app_server.Data
{
  public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure the relationship between User and Task
            modelBuilder.Entity<Assignment>()
                .HasOne(t => t.User)
                .WithMany(u => u.Assignments)
                .HasForeignKey(t => t.UserId);
        }
    }
}