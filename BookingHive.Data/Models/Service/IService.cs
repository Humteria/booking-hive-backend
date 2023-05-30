using BookingHive.Data.Models.Accounts;
using BookingHive.Data.Models.Miscellaneous;
using System.ComponentModel.DataAnnotations;

namespace BookingHive.Data.Models.Service;

/// <summary>
/// Represents a BookingHive Service that can be booked by <see cref="ICustomer"/>s
/// </summary>
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

    /// <summary>
    /// Supplier that owns the Service
    /// </summary>
    public ISupplier Supplier { get; set; } 

    /// <summary>
    /// Consultant which provides the Service
    /// </summary>
    public IConsultant Consultant { get; set; }
    
    /// <summary>
    /// Collection of booked Bookings
    /// </summary>
    public ICollection<IBooking> Bookings { get; set; }
}
