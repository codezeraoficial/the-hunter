using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class UserCombineMapping : IEntityTypeConfiguration<UserCombine>
    {
        public void Configure(EntityTypeBuilder<UserCombine> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.JobOfferId)
                 .IsRequired(false);

            builder.Property(c => c.EmployeeId)
                 .IsRequired(false);

            builder.Property(c => c.Gotcha)
                 .IsRequired(false);

            builder.Property(c => c.Dropped)
               .IsRequired(false);

            builder.ToTable("UsersCombine");
        }
    }
}
