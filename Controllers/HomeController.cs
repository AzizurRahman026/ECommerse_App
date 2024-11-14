using ECommerse_App;
using Microsoft.AspNetCore.Mvc;


namespace ECommerse_App.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("E-Commerse Root Page...");
        }
    }
}

namespace ECommerse_App
{
    class IActionResult<T>
    {
    }
}