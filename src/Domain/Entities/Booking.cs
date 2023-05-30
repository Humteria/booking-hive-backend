namespace BookingHive.Domain.Entities;

public class Booking : BaseAuditableEntity
{
    public Service? Service { get; set; }

    public DateTime BookingTime { get; set; }
}
