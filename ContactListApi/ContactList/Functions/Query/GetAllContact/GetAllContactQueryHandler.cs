using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.GetAllContact;

public sealed class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, List<Contact>>
{

    private readonly ContactContext _context;

    public GetAllContactQueryHandler(ContactContext context)
    {
        this._context = context;
    }

    public async Task<List<Contact>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contact.ToListAsync();
    }
}
