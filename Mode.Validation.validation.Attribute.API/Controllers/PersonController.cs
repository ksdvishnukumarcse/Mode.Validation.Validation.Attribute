using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mode.Validation.validation.Attribute.Common.DTO;
using System.Threading.Tasks;

namespace Mode.Validation.validation.Attribute.API.Controllers
{
    [Route("validate")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertData(Person payload)
        {
            ObjectResult res = null;
            res = StatusCode(StatusCodes.Status200OK, "Success");
            return res;
        }
    }
}
