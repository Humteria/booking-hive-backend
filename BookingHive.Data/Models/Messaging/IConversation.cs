using BookingHive.Data.Models.Accounts.General;

namespace BookingHive.Data.Models.Messaging;

public interface IConversation
{
    public ICollection<IProfile> Participants { get; set; }

    public ICollection<IMessage> Messages { get; set; }
}
