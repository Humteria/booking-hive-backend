using BookingHive.Application.Common.Mappings;
using BookingHive.Domain.Entities;

namespace BookingHive.Application.Common.Models.DataTransferObjects;

public class BookingDto : IMapFrom<Booking>
{
    public int Id { get; init; }

    public int ServiceId { get; init; }

    public DateTime BookingTime { get; init; }
}
