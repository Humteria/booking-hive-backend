using BookingHive.Data.Models.Messaging;
using BookingHive.Data.Models.Miscellaneous;

namespace BookingHive.Data.Models.Accounts.General;

public abstract class UserProfile : UserAccount, IProfile
{
    public string Name { get; set; }
    
    public IImage? ProfilePicture { get; set; }
    
    public ICollection<IConversation> Conversations { get; set; } = new List<IConversation>();
    
    public string Phone { get; set; }

    public UserProfile(string username, string email, ILogin login, string name, string phone)
        : base(username, email, login) =>
        (Name, Phone) = (name, phone);
}
