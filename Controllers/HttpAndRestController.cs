using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ReactDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HttpAndRestController : ControllerBase
    {
        //Svarar med ett hej
        //Vilken Content-type får vi?
        [HttpGet("hello")]
        public ActionResult<string> Hello()
        {
            return Ok("<h1>hej</h1>");
        }
        //Returnerar hej i en h1-html tag. 
        [HttpGet("html-hello")]
        public ContentResult HtmlHello()
        {
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<h1>hej</h1>"
            };
        }
        //Returnerar hej som json. 
        [HttpGet("json-hello")]
        public ContentResult JsonHello()
        {
            return Content("{ \"meddelande\": \"hej\"}", "application/json");
        }

        //Exercises!

        [HttpGet("this-is-you")]
        public ActionResult ThisIsYou()
        {
            // return the host of whoever sent the request

            return Ok(Request.Host.Value);
        }

        [HttpPost("you-sent-me-this")]
        public async Task<ActionResult> YouSentMeThis()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var hej = await reader.ReadToEndAsync();
                return Ok(hej);
            }
        }

        [HttpPost("i-only-answer-if-i-know-who-you-are")]
        public ActionResult IOnlyAnswerIfIKnowWhoYouAre(IFormCollection data)
        {
            // return Ok if "name" key exists in the body


            if (data.Keys.Contains("name"))
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
