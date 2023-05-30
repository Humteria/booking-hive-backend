namespace BookingHive.Domain.Events;

public class ServiceBookedEvent : BaseEvent
{
    public ServiceBookedEvent(Booking booking) => Booking = booking;

    public Booking Booking { get; }
}
