using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    public class PlatformController : BaseApiController
    {

        public PlatformController()
        {
            
        }

        [HttpPost]
        public ActionResult TestInboundConnection()
        {
            Console.WriteLine("Inbound Post Command Service");

            return Ok("Success");
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok("Hello get all");
        }
    }
}
