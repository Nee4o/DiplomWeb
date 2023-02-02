using DiplomWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiplomWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        public RZDDatabaseContext context { get; set; }

        public RequestController()
        {
            context = new RZDDatabaseContext();
        }

        [HttpGet("GetList")]
        public ActionResult<Request> Get()
        {
            var ret = context.Requests.ToList();
            return new ObjectResult(ret);
        }
    }
}