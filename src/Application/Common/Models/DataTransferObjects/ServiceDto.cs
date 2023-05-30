using BookingHive.Application.Common.Mappings;
using BookingHive.Domain.Entities;
using BookingHive.Domain.Enums;

namespace BookingHive.Application.Common.Models.DataTransferObjects;

public class ServiceDto : BaseDto, IMapFrom<Service>
{
    public string? Title { get; init; }

    public string? Description { get; init; }

    public ServiceState State { get; init; }

    public TimeSpan Length { get; init; }

    public ICollection<int>? BookingIds { get; init; }
}
