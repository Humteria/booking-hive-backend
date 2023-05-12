using Microsoft.AspNetCore.Mvc;

namespace BookingHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : Controller
    {
        [HttpGet]
        public ActionResult<string> Index()
        {
            return "Works";
        }
    }
}
