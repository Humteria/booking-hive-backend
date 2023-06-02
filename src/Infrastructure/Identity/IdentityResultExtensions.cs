using BookingHive.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace BookingHive.Infrastructure.Identity;

public static class IdentityResultExtensions
{
    public static Result ToApplicationResult(this IdentityResult result) =>
        result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));

    public static ValueResult<T> ToApplicationValueResult<T>(this IdentityResult result, T value) =>
        result.Succeeded
            ? ValueResult<T>.Success(value)
            : new ValueResult<T>(Result.Failure(result.Errors.Select(e => e.Description)));
}
