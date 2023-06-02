using BookingHive.Application.Common.Interfaces;
using BookingHive.Application.Common.Models;
using MediatR;

namespace BookingHive.Application.Authentication.Commands;

public class AuthenticateCommand : IRequest<ValueResult<AuthenticatedUserDto>>
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, ValueResult<AuthenticatedUserDto>>
{
    private readonly IIdentityService _identity;

    public AuthenticateCommandHandler(IIdentityService identity) =>
        _identity = identity;

    public async Task<ValueResult<AuthenticatedUserDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        ValueResult<string> jwtResult = await _identity.AuthenticateAsync(request.Username, request.Password);

        if (!jwtResult.Succeeded)
            return new ValueResult<AuthenticatedUserDto>(jwtResult);

        return ValueResult<AuthenticatedUserDto>.Success(new AuthenticatedUserDto
        {
            Username = request.Username,
            Token = jwtResult.Value
        });
    }
}
