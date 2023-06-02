using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookingHive.Application.Common.Interfaces;
using BookingHive.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BookingHive.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
    private readonly IAuthorizationService _authorizationService;
    private readonly IOptions<JwtSettings> _jwtSettings;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        _authorizationService = authorizationService;
        _jwtSettings = jwtSettings;
    }

    public async Task<string?> GetUserNameAsync(string userId)
    {
        var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        return user.UserName;
    }

    public async Task<ValueResult<string>> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await _userManager.CreateAsync(user, password);

        return result.ToApplicationValueResult(user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null && await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        if (user == null)
        {
            return false;
        }

        var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await _userManager.DeleteAsync(user);

        return result.ToApplicationResult();
    }
    public async Task<ValueResult<string>> AuthenticateAsync(string username, string password)
    {
        ApplicationUser? user = await _userManager.FindByNameAsync(username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, password))
            return ValueResult<string>.Failure(new List<string> { "Invalid Password" });

        string? jwt = GenerateJsonWebToken(user);

        return jwt == null ?
            ValueResult<string>.Failure(new List<string> { "Failed to generate JWT" }) :
            ValueResult<string>.Success(jwt);
    }

    public string? GenerateJsonWebToken(ApplicationUser user)
    {
        if (string.IsNullOrEmpty(user.UserName))
            return null;

        Claim[] claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        SymmetricSecurityKey signingKey = new(Encoding.UTF8.GetBytes(_jwtSettings.Value.SigningKey ?? string.Empty));

        JwtSecurityToken token = new(
            issuer: _jwtSettings.Value.Issuer,
            audience: _jwtSettings.Value.Audience,
            expires: DateTime.UtcNow.Add(_jwtSettings.Value.Expiration),
            claims: claims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
