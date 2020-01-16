using Jobber.IO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobber.IO.Data.Mappings
{
    public class SkillMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");

            builder.Property(c => c.Link)
                 .IsRequired();
            
            builder.ToTable("Skills");
        }
    }
}
