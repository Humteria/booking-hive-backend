using BookingHive.Application.Common.Models;

namespace BookingHive.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);

    Task<bool> IsInRoleAsync(string userId, string role);

    Task<bool> AuthorizeAsync(string userId, string policyName);

    Task<ValueResult<string>> CreateUserAsync(string username, string password);

    Task<Result> DeleteUserAsync(string userId);
}
