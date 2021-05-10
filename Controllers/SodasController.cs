using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SodasController : ControllerBase
    {
        private List<string> Sodas = new List<string>
        {
            "Coca Cola",
            "Fanta",
            "Trocadero",
            "Sprite"
        };


        [HttpGet]
        public ActionResult GetAllSodas()
        {
            return Ok(Sodas);
        }
    }
}
