using BookingHive.Data.Models.Messaging;
using BookingHive.Data.Models.Miscellaneous;

namespace BookingHive.Data.Models.Accounts.General;

public interface IProfile : IAccount
{
    public string Name { get; set; }

    public IImage? ProfilePicture { get; set; }

    public ICollection<IConversation> Conversations { get; set; }

    public string Phone { get; set; }
}
