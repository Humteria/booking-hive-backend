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
    public async Task<ActionResult<List<ServiceDto>>> GetAllServices() =>
        await Mediator.Send(new GetAllServicesQuery());

    [HttpGet("bookings/{serviceId}")]
    public async Task<ActionResult<List<BookingDto>>> GetServiceBookings([FromRoute] int serviceId) =>
        await Mediator.Send(new GetServiceBookingsQuery { ServiceId = serviceId });
}
