using AutoMapper;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ReactDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly CurriculumVitaeDbContext _context;
        private IMapper _mapper;
        public ContactsController(CurriculumVitaeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ContactMe([FromBody] ContactMeRequest request)
        {
            try
            {
                var contactMe = _mapper.Map<ContactMe>(request);
                _context.ContactMes.Add(contactMe);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok();
        }
    }
}
