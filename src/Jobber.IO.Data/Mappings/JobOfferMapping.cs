using Jobber.IO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jobber.IO.Data.Mappings
{
    public class JobOfferMapping : IEntityTypeConfiguration<JobOffer>
    {
        public void Configure(EntityTypeBuilder<JobOffer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.Description)
                 .IsRequired()
                 .HasColumnType("varchar(1000)");

            builder.Property(c => c.Long)
                 .IsRequired();                  
                 
            builder.HasMany(e => e.Techs)
                .WithOne(t => t.Employee)
                .HasForeignKey(e => e.EmployeeId);

            builder.HasMany(e => e.Skills)
                .WithOne(s => s.Employee)
                .HasForeignKey(e => e.EmployeeId);
                       
            builder.ToTable("JobOffers");
        }
    }
}
