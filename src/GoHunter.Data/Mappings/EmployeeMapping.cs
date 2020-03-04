
using GoHunter.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoHunter.Data.Mappings
{
    public class EmployeeMapping : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(e => e.LastName)
                 .IsRequired()
                 .HasColumnType("varchar(100)");            

            builder.Property(e => e.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");
                       
            builder.HasOne(e => e.Address)
                .WithOne(a => a.Employee);     

            builder.HasMany(e => e.Techs)
                .WithOne(t => t.Employee)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasMany(e => e.Skills)
                .WithOne(s => s.Employee)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasMany(e => e.Occupations)
              .WithOne(s => s.Employee)
              .HasForeignKey(e => e.EmployeeId);


            builder.ToTable("Employees");
        }
    }
}
