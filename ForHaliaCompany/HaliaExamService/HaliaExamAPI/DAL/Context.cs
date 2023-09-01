using HaliaExamAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HaliaExamAPI.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasIndex(u => u.email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.phone).IsUnique();
        }

        public DbSet<User> users { get; set; }

        public DbSet<Case> cases { get; set; }

        public DbSet<CaseStatus> casesstatus { get; set; }

        public DbSet<AssignedCase> assignedcases { get; set; }

    }
}