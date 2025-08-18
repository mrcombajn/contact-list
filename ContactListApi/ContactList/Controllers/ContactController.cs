using ContactList.Models;
using ContactList.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private ContactContext _context;

        public ContactController(ContactContext contactContext)
        {
            this._context = contactContext;
        }

        // GET api/values
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            return _context
                .Contact
                .Include(contact => contact.Category)
                .Include(contact => contact.SubCategory)
                .ToList();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContact(int id)
        {
            var contact = _context.Contact.SingleOrDefault(contact => contact.Id == id);
            if (contact == null)
                return NotFound();

            return Ok(contact);
        }

        // POST api/values
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] Contact contact)
        {
            //jeśli mail sie powtarza to wyrzuć exception

            _context.Contact.Add(contact);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(GetContact), "Contact", new { id = contact.Id }, contact);
        }

        // PUT api/values/5
        [HttpPut("{index}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Contact>> Put(int id, [FromBody] Contact item)
        {
            return null;
        }

        // DELETE api/values/5
        [HttpDelete("{index}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(int index)
        {
            return null;
        }

    }
}
