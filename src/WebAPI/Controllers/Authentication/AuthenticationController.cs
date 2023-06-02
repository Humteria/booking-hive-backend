using BookingHive.Application.Authentication;
using BookingHive.Application.Authentication.Commands;
using BookingHive.Application.Common.Models;
using BookingHive.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Authentication;

public class AuthenticationController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<AuthenticatedUserDto>> Authenticate(AuthenticateCommand command)
    {
        ValueResult<AuthenticatedUserDto> jwtResult = await Mediator.Send(command);

        return 
            jwtResult.Succeeded ?
                Ok(jwtResult.Value) :
                Unauthorized();
    }
}
