using BookingHive.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BookingHive.Application.Services.EventHandlers;

public class ServiceBookedEventHandler : INotificationHandler<ServiceBookedEvent>
{
    private readonly ILogger<ServiceBookedEventHandler> _logger;

    public ServiceBookedEventHandler(ILogger<ServiceBookedEventHandler> logger) => _logger = logger;

    public Task Handle(ServiceBookedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
