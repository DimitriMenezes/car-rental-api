using Car.Rental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Car.Rental.Domain.EntitiesMapping
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(i => i.ReferenceNumber)
                .HasMaxLength(10)              
                .IsRequired(true);

            builder.Property(i => i.Street)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(i => i.City)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(i => i.State)
                .HasMaxLength(2)
                .IsRequired(true);

            builder.Property(i => i.ZipCode)
                .HasMaxLength(8)
                .IsRequired(true);       

            builder.Property(i => i.Complement)
                .HasMaxLength(100)
                .IsRequired(false);
        }
    }
}
