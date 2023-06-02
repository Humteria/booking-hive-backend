namespace BookingHive.Infrastructure.Identity;

public class JwtSettings
{
    public string? SigningKey { get; init; }

    public string? Issuer { get; init; }

    public string? Audience { get; init; }

    public int ExpiryInMinutes { get; init; }

    public TimeSpan Expiration => TimeSpan.FromMinutes(ExpiryInMinutes);
}
