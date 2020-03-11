using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class OccupationMapping : IEntityTypeConfiguration<Occupation>
    {
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");

            builder.Property(c => c.CompanyName)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
               .IsRequired();

            builder.ToTable("Occupations");

        }
    }
}
