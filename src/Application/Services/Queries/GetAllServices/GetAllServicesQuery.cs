using AutoMapper;
using BookingHive.Application.Common.Interfaces;
using BookingHive.Application.Common.Mappings;
using BookingHive.Application.Common.Models.DataTransferObjects;
using MediatR;

namespace BookingHive.Application.Services.Queries.GetAllServices;

public record GetAllServicesQuery : IRequest<List<ServiceDto>> { }

public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllServicesQueryHandler(IApplicationDbContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

    public Task<List<ServiceDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken) =>
        _context.Services
                .ProjectToListAsync<ServiceDto>(_mapper.ConfigurationProvider);
}
