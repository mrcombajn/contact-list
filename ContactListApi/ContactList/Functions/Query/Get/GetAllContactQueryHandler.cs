using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.Get
{
    public class GetAllContactQueryHandler : IRequestHandler<GetContactQuery, List<Contact>>
    {

        private readonly ContactContext _context;

        public GetAllContactQueryHandler(ContactContext context)
        {
            this._context = context;
        }

        public Task<List<Contact>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            return _context.Contact.ToListAsync();
        }
    }
}
