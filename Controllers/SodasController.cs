using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReactDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SodasController : ControllerBase
    {
        private Dictionary<string, string> Sodas = new Dictionary<string, string>();

        public SodasController()
        {
            Sodas.Add("1", "Cola");
            Sodas.Add("2", "Fanta");
            Sodas.Add("3", "Sprite");
            Sodas.Add("4", "Trocadero");
        }


        [HttpGet]
        public ActionResult GetAllSodas()
        {
            return Ok(Sodas);
        }

        [HttpGet("{id}")]
        public ActionResult GetSpecificSoda(string id)
        {
            var sodaToReturn = Sodas[id];
            return Ok(sodaToReturn);
        }

        [HttpPost]
        public ActionResult AddSoda()
        {
            return Created("", "");
        }

        [HttpPut]
        public ActionResult ReplaceSoda()
        {
            return Ok("This is the rout for replacing sodas");
        }

        [HttpDelete]
        public ActionResult DeleteSoda()
        {
            return NoContent();
        }
    }
}
