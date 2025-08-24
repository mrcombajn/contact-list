using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.GetContact;

public sealed class GetContactQueryHandler : IRequestHandler<GetContactQuery, Contact>
{

    private readonly ContactContext _context;

    public GetContactQueryHandler(ContactContext context)
    {
        _context = context;
    }

    public async Task<Contact> Handle(GetContactQuery request, CancellationToken cancellationToken)
    {
        var contact = await _context
            .Contact
            .Include(e => e.Category)
            .Include(e => e.SubCategory)
            .FirstAsync(e => e.Id == request.Id, cancellationToken);

        return contact;
    }
}
