using ContactList.Models;
using ContactList.Models.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.GetContact;

public sealed class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto>
{

    private readonly ContactContext _context;

    public GetContactQueryHandler(ContactContext context)
    {
        _context = context;
    }

    public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _context
            .Contact
            .Include(e => e.Category)
            .Include(e => e.SubCategory)
            .FirstAsync(e => e.Id == request.Id, cancellationToken);

        return new ContactDto()
        {
            Id = contact.Id,
            Name = contact.Name,
            Surname = contact.Surname,
            Email = contact.Email,
            Category = contact.Category.Name,
            SubCategory = contact.SubCategory.Name,
            PhoneNumber = contact.PhoneNumber,
            BirthdayDate = contact.BirthdayDate,
        };
    }
}
