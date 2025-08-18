using ContactList.Functions.Query.GetContactList;
using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;
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

        private IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        #region GET

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<Contact>>> Get()
        {
            var request = new GetContactQuery();
            var result = await _mediator.Send(request);

            return result;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetContact(Guid id)
        {
            var request = new GetContactQuery()
            {
                Id = id
            };

            var result = await _mediator.Send(request);

            return result;
        }


        #endregion

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
