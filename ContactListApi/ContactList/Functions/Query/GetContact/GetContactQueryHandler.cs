using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;

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
        var contact = await _context.Contact.FindAsync(request.Id);

        return contact;
    }
}
