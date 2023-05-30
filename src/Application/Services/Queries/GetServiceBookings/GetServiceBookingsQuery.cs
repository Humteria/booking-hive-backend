using AutoMapper;
using BookingHive.Application.Common.Interfaces;
using BookingHive.Application.Common.Mappings;
using BookingHive.Application.Common.Models.DataTransferObjects;
using MediatR;

namespace BookingHive.Application.Services.Queries.GetServiceBookings;

public record class GetServiceBookingsQuery : IRequest<List<BookingDto>>
{
    public int ServiceId { get; init; }
}

public class GetServiceBookingsQueryHandler : IRequestHandler<GetServiceBookingsQuery, List<BookingDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetServiceBookingsQueryHandler(IApplicationDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

    public Task<List<BookingDto>> Handle(GetServiceBookingsQuery request, CancellationToken cancellationToken) =>
        _context.Services
                .Single(s => s.Id == request.ServiceId)
                .Bookings
                .AsQueryable()
                .ProjectToListAsync<BookingDto>(_mapper.ConfigurationProvider);
}
