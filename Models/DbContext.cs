using Microsoft.EntityFrameworkCore;
namespace FreelanceGo_MasterV2.Models
{
    public class dDbContext : DbContext
    {
        public dDbContext(DbContextOptions<dDbContext> options)
                : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freelance>()
                .HasIndex(f => new { f.UserName, f.Email })
                .IsUnique(true);
        }

        public DbSet<Employer> Employer { get; set; }
        public DbSet<Freelance> Freelance { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectSkill> ProjectSkill { get; set; }
        public DbSet<FreelanceSkill> FreelanceSkill { get; set; }
        public DbSet<Skill> Skill { get; set; }
    }
}