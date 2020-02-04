using GoHunter.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoHunter.Data.Mappings
{
    public class TechMapping : IEntityTypeConfiguration<Tech>
    {
        public void Configure(EntityTypeBuilder<Tech> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");

            builder.Property(c => c.Level)
                 .IsRequired();

            builder.ToTable("Techs");
        }
    }
}
