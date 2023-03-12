using EcoTeleport.Model;
using Microsoft.EntityFrameworkCore;
using Route = EcoTeleport.Model.Route;

namespace EcoTeleport.Data
{
    public class DataContext : DbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Goal> Goals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Route>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.user_uuid);

            modelBuilder.Entity<Route>()
                .HasOne(r => r.Goal)
                .WithMany()
                .HasForeignKey(r => r.goal_uuid);

            base.OnModelCreating(modelBuilder);
        }
    }
}