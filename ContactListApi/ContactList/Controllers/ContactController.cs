using ContactList.Functions.Command.CreateContact;
using ContactList.Functions.Command.DeleteContact;
using ContactList.Functions.Command.UpdateContact;
using ContactList.Functions.Query.GetAllContact;
using ContactList.Models.Dto;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers;

[Route("api/contact")]
[ApiController]
public class ContactController : ControllerBase
{
    private ISender _sender;

    public ContactController(ISender sender)
    {
        this._sender = sender;
    }


    #region GET

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<DummyContactDto>>> Get()
    {
        var request = new GetAllContactQuery();
        var result = await _sender.Send(request);

        return Ok(result);
    }

    [HttpGet("/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContactDto>> GetContact(int id)
    {
        var request = new GetContactQuery() { Id = id };

        try
        {
            var result = await _sender.Send(request);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch
        {
            return new NotFoundObjectResult("Contact with given id not found!");
        }
    }


    #endregion

    // POST api/values

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Post([FromBody] ContactDto contact, CancellationToken cancellationToken)
    {
        var command = new CreateContactCommand()
        {
            Email = contact.Email,
            Name = contact.Name,
            Surname = contact.Surname,
            Password = contact.Password,
            Category = contact.Category,
            SubCategory = contact.SubCategory,
            PhoneNumber = contact.PhoneNumber,
            BirthdayDate = contact.BirthdayDate,
        };

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

    // PUT api/values/5
    [HttpPut("{index}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Contact>> Put(int id, [FromBody] ContactDto contact, CancellationToken cancellationToken)
    {

        var command = new UpdateContactCommand()
        {
            Id = id,
            Email = contact.Email,
            Name = contact.Name,
            Surname = contact.Surname,
            Password = contact.Password,
            Category = contact.Category,
            SubCategory = contact.SubCategory,
            PhoneNumber = contact.PhoneNumber,
            BirthdayDate = contact.BirthdayDate,
        };

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    // DELETE api/values/5
    [HttpDelete("{index}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(int index, CancellationToken cancellationToken)
    {
        var command = new DeleteContactCommand
        {
            Id = index,
        };

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

}
