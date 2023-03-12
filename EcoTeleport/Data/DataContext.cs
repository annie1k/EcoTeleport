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
        public DbSet<GoalRoute> GoalRoutes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<UserGoal> UserGoals { get; set; }
        public DbSet<UserRoute> UserRoutes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGoal>()
                .HasKey(ug => new { ug.user_uuid, ug.goal_uuid });
            modelBuilder.Entity<UserGoal>()
                .HasOne(ug => ug.User)
                .WithMany(u => u.UserGoals)
                .HasForeignKey(ug => ug.user_uuid);
            modelBuilder.Entity<UserGoal>()
                .HasOne(ug => ug.Goal)
                .WithMany(g => g.UserGoals)
                .HasForeignKey(ug => ug.goal_uuid);

            modelBuilder.Entity<UserRoute>()
                .HasKey(ur => new { ur.user_uuid, ur.route_uuid });
            modelBuilder.Entity<UserRoute>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoutes)
                .HasForeignKey(ur => ur.user_uuid);
            modelBuilder.Entity<UserRoute>()
                .HasOne(ur => ur.Route)
                .WithMany(r => r.UserRoutes)
                .HasForeignKey(ur => ur.route_uuid);

            modelBuilder.Entity<GoalRoute>()
                .HasKey(gr => new { gr.goal_uuid, gr.route_uuid });
            modelBuilder.Entity<GoalRoute>()
                .HasOne(gr => gr.Goal)
                .WithMany(g => g.GoalRoutes)
                .HasForeignKey(gr => gr.goal_uuid);
            modelBuilder.Entity<GoalRoute>()
                .HasOne(gr => gr.Route)
                .WithMany(r => r.GoalRoutes)
                .HasForeignKey(gr => gr.route_uuid);
        }
    }
}