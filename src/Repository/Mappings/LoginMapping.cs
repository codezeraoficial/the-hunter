
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class LoginMapping : IEntityTypeConfiguration<Login>
    {

        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Email)
                 .IsRequired()
                 .HasColumnType("varchar(50)");     
            
            builder.Property(e => e.Username)
                 .IsRequired()
                 .HasColumnType("varchar(50)");     
            
            builder.Property(e => e.Password)
                 .IsRequired()
                 .HasColumnType("varchar(50)");     
            
            builder.Property(e => e.LastPassword)
                 .IsRequired()
                 .HasColumnType("varchar(50)");     

            builder.ToTable("Employees");
        }
    }
}
