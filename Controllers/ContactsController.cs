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
        private readonly CurriculumVitaeDbContext _context;
        public ContactsController(CurriculumVitaeDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> ContactMe([FromBody] ContactMeRequest request)
        {
            var contactMe = new ContactMe {
                Email = request.Email,
                Message = request.Message,
                Name = request.Name,
                CreatedAt = DateTime.Now
            };
            _context.ContactMes.Add(contactMe);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
