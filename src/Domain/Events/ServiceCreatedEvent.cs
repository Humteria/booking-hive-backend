namespace BookingHive.Domain.Events;

public class ServiceCreatedEvent : BaseEvent
{
    public ServiceCreatedEvent(Service service) => Service = service;

    public Service Service { get; }
}
