using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        [HttpPost]
        public ActionResult ContactMe([FromBody] ContactMeRequest request)
        {
            return Ok();
        }
    }
}
