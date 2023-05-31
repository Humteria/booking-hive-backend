using BookingHive.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookingHive.Application.Services.EventHandlers;

public class ServiceCreatedEventHandler : INotificationHandler<ServiceCreatedEvent>
{
    private readonly ILogger<ServiceCreatedEventHandler> _logger;

    public ServiceCreatedEventHandler(ILogger<ServiceCreatedEventHandler> logger) => _logger = logger;

    public Task Handle(ServiceCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
