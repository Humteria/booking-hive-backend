using BookingHive.Data.Models.Accounts.General;
using BookingHive.Data.Models.Service;

namespace BookingHive.Data.Models.Accounts.Users;

public interface IConsultant : IProfile
{
    public ICollection<IService> Services { get; set; }
}
