using BookingHive.Data.Models.Accounts;
using BookingHive.Data.Models.Miscellaneous;

namespace BookingHive.Data.Models.Service;

public interface IService
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ServiceState State { get; set; }

    public ICollection<IImage> Pictures { get; set; }

    public TimeSpan Length { get; set; }

    // TODO: Location // public ILocation Location { get; set; }

    // TODO: Price // public double Price { get; set; }

    public ISupplier Supplier { get; set; } 

    public IConsultant Consultant { get; set; }
    
    public ICollection<IBooking> Bookings { get; set; }
}
