namespace BookingHive.Data.Models.Accounts.General;

public abstract class UserAccount : IAccount
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public ILogin Login { get; set; }

    public UserAccount(string username, string email, ILogin login) => 
        (Username, Email, Login) = (username, email, login);
}
