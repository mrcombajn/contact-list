using ContactList.Models;
using ContactList.Models.Dto;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.GetAllContact;

public sealed class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, IEnumerable<ContactDto>>
{

    private readonly ContactContext _context;

    public GetAllContactQueryHandler(ContactContext context)
    {
        this._context = context;
    }

    public async Task<IEnumerable<ContactDto>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
    {
        var contacts = await _context
            .Contact
            .Include(e => e.Category)
            .Include(e => e.SubCategory).ToListAsync();

        return contacts.Select(c => new ContactDto()
        {
            Id = c.Id,
            Name = c.Name,
            Surname = c.Surname,
            Email = c.Email,
            Category = new CategoryDto() { Id = c.Category.Id, Name = c.Category.Name },
            SubCategory = new SubCategoryDto() { Id = c.SubCategory.Id, Name = c.SubCategory.Name },
            PhoneNumber = c.PhoneNumber,
            BirthdayDate = c.BirthdayDate,
        });
    }
}
