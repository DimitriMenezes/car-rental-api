using Car.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Car.Rental.Domain.EntitiesMapping
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.Property(i => i.Birthday)                
                .IsRequired(true);

            builder.Property(i => i.Cpf)
                .HasMaxLength(11)
                .IsRequired(true);

            builder.Property(i => i.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(i => i.Password)
                .HasMaxLength(200)
                .IsRequired(true);

            builder.HasOne(i => i.Address);
        }
    }
}
