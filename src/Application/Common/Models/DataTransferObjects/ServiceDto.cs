using AutoMapper;
using BookingHive.Application.Common.Mappings;
using BookingHive.Domain.Entities;
using BookingHive.Domain.Enums;

namespace BookingHive.Application.Common.Models.DataTransferObjects;

public class ServiceDto : IMapFrom<Service>
{
    public int Id { get; init; }
    
    public string? Title { get; init; }

    public string? Description { get; init; }

    public ServiceState State { get; init; }

    public TimeSpan Length { get; init; }

    public ICollection<int>? BookingIds { get; init; }

    public void Mapping(Profile profile) =>
        profile.CreateMap<Service, ServiceDto>()
            .ForMember(dest => dest.BookingIds,
                       opt => opt.MapFrom(src => src.Bookings.Select(b => b.Id)));
}
