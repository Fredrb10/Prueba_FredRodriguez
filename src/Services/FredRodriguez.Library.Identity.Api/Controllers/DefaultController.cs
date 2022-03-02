using Microsoft.AspNetCore.Mvc;


namespace FredRodriguez.Library.Identity.Api.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Running Identity...";
        }
    }
}
