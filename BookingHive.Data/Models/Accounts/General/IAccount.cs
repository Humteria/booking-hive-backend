namespace BookingHive.Data.Models.Accounts.General;

public interface IAccount
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public ILogin Login { get; set; }
}
