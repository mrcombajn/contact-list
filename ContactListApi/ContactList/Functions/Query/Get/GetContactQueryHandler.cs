using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;

namespace ContactList.Functions.Query.Get
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, Contact>
    {

        private readonly ContactContext _context;

        public GetContactQueryHandler(ContactContext context)
        {
            this._context = context;
        }

        public async Task<Contact> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contact = await _context.Contact.FindAsync(request.Id);

            if (contact is null)
            {
                throw new Exception("Not found any contact with given id!");
            }

            return contact;
        }
    }
}
