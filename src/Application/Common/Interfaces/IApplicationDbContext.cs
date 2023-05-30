//using BookingHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingHive.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    // DbSet<Entity> Entities { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
