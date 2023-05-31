namespace BookingHive.Domain.Entities;

public class Service : BaseAuditableEntity
{
    private readonly IList<Booking> _bookings = new List<Booking>();

    public string? Title { get; set; }

    public string? Description { get; set; }

    public ServiceState State { get; set; }

    public TimeSpan? Length { get; set; } = null;

    public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

    public bool AddBooking(Booking booking)
    {
        if (_bookings.Any(b => b.Id == booking.Id))
            return false;

        _bookings.Add(booking);

        AddDomainEvent(new ServiceBookedEvent(booking));

        return true;
    }
}
