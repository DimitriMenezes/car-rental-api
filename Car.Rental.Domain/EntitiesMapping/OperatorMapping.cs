using Car.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Domain.EntitiesMapping
{
    public class OperatorMapping : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.Property(i => i.EnrollmentCode)
                .HasMaxLength(15)
                .IsRequired(true);
            
            builder.Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(i => i.Password)
                .HasMaxLength(200)
                .IsRequired(true);
        }
    }
}
