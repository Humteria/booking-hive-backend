using BookingHive.Application.Common.Interfaces;

namespace BookingHive.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
