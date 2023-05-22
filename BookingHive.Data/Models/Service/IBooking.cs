using BookingHive.Data.Models.Accounts.Users;

namespace BookingHive.Data.Models.Service;

public interface IBooking
{
    public int Id { get; set; }
    
    public IService Service { get; set; }
    
    public DateTime Time { get; set; }

    public ICustomer Customer { get; set; }
}
