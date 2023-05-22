namespace BookingHive.Data.Models.Accounts.General;

public interface ILogin
{
    public int Id { get; set; }

    public string Password { get; set; }

    public IAccount Account { get; set; }
}
