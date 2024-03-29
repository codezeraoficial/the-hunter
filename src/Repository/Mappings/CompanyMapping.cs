﻿
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                 .IsRequired()
                 .HasColumnType("varchar(50)");

            builder.Property(c => c.Document)
                 .IsRequired()
                 .HasColumnType("varchar(20)");        
                         
            builder.HasOne(c => c.Address)
                .WithOne(a => a.Company);

            builder.HasMany(e => e.JobOffers)
                .WithOne();               

            builder.ToTable("Companies");
        }
    }
}
