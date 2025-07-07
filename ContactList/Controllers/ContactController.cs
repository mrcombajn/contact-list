using ContactList.Repositories;
using ContactList.Repositories.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController
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
            return new List<Contact>();
        }

        // GET api/values/5
        [HttpGet("{index}")]
        public async Task<ActionResult<Contact>> Get(int index)
        {
            return null;
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Contact>> Post([FromBody] Contact item)
        {

            return null;
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
