using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Manager")]
    public class DashboardController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetTest()
        {
            return Ok("les go");
        }
    }
}