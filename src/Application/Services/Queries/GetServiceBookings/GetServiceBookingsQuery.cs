using System.Data;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingHive.Application.Common.Interfaces;
using BookingHive.Application.Common.Models.DataTransferObjects;
using BookingHive.Application.Common.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookingHive.Application.Services.Queries.GetServiceBookings;

[Authorize(Roles = "Administrator")]
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
        Task.FromResult(
            _context.Services
                .AsNoTracking()
                .Include(s => s.Bookings)
                .SingleOrDefault(s => s.Id == request.ServiceId)
                ?.Bookings
                ?.AsQueryable()
                ?.ProjectTo<BookingDto>(_mapper.ConfigurationProvider)
                ?.ToList() ?? new List<BookingDto>());
}
