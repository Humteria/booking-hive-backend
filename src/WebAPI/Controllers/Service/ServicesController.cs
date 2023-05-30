using BookingHive.Application.Common.Models.DataTransferObjects;
using BookingHive.Application.Common.Security;
using BookingHive.Application.Services.Queries.GetAllServices;
using BookingHive.Application.Services.Queries.GetServiceBookings;
using BookingHive.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.Service;

[Authorize]
public class ServicesController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ServiceDto>>> GetAllServices(GetAllServicesQuery query) =>
        await Mediator.Send(query);

    [HttpGet("bookings")]
    public async Task<ActionResult<List<BookingDto>>> GetServiceBookings([FromQuery] GetServiceBookingsQuery query) =>
        await Mediator.Send(query);
}
