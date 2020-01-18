using Jobber.IO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Jobber.IO.Data.Context
{
    public class JobberDbContext: DbContext
    {
        public JobberDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tech> Techs { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(JobberDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
