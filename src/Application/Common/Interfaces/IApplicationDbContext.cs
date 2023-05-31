using BookingHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingHive.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Service> Services { get; }

    DbSet<Booking> Bookings { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
