using BookingHive.Domain.Entities;
using BookingHive.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingHive.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.Property(s => s.Title)
               .HasMaxLength(100)
               .IsUnicode()
               .IsRequired();
        
        builder.Property(s => s.Description)
               .IsUnicode()
               .HasMaxLength(350);

        builder.Property(s => s.State)
               .HasDefaultValue(ServiceState.Active);
    }
}
