using BookingHive.Data.Models.Accounts.General;

namespace BookingHive.Data.Models.Messaging;

public interface IMessage
{
    public string Content { get; set; }

    public IProfile Sender { get; set; }
}
