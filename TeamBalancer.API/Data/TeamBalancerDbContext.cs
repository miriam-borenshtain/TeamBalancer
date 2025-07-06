using Microsoft.EntityFrameworkCore;
using TeamBalancer.API.Models.Domain;

namespace TeamBalancer.API.Data
{
    public class TeamBalancerDbContext : DbContext
    {
        public TeamBalancerDbContext(DbContextOptions<TeamBalancerDbContext> dbContextOptions): base(dbContextOptions) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Members)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Manager)
                .WithMany()
                .HasForeignKey(t => t.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
