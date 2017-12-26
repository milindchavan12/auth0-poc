using System.Web.Http;

namespace Shipment.API.Controllers
{
    [Authorize]
    public class ShipmentsController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}
