using BookingHive.Data.Models.Accounts.General;
using BookingHive.Data.Models.Miscellaneous;
using BookingHive.Data.Models.Service;

namespace BookingHive.Data.Models.Accounts.Users;

public interface ISupplier : IProfile
{
    public IImage Banner { get; set; }

    public ICollection<IService> Services { get; set; }
}
