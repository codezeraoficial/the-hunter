using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Context
{
    public class GoHunterDbContext: DbContext
    {
        public GoHunterDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Login> Login { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Tech> Techs { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in GetStringAttributes(modelBuilder))
            {
                property.SetColumnType("varchar(100)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GoHunterDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }

        private static IEnumerable<IMutableProperty> GetStringAttributes(ModelBuilder modelBuilder)
        {
            return modelBuilder.Model
                               .GetEntityTypes()
                               .SelectMany(
                                e => e.GetProperties()
                                    .Where(p => p.ClrType == typeof(string)));
        }
    }
}
