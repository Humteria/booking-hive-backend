using BookingHive.Application.Common.Interfaces;
using BookingHive.Domain.Enums;
using BookingHive.Domain.Entities;
using MediatR;
using BookingHive.Domain.Events;

namespace BookingHive.Application.Services.Commands.CreateService;

public record CreateServiceCommand : IRequest<int>
{
    public string? Title { get; init; }

    public string? Description { get; init; }

    public TimeSpan Length { get; init; }
}

public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateServiceCommandHandler(IApplicationDbContext context) => _context = context;

    public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
        Service entity = new()
        {
            Title = request.Title,
            Description = request.Description,
            Length = request.Length,
            State = ServiceState.Active
        };

        entity.AddDomainEvent(new ServiceCreatedEvent(entity));

        _context.Services.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
