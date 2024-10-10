using Microsoft.EntityFrameworkCore;
using ViteNetCoreApp.Domain.Models.Models;

namespace ViteNetCoreApp.Infrastructure.Repositories
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Tasks>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks) 
                .WithOne(t => t.User) 
                .HasForeignKey(t => t.UserId); 
        }
    }
}
