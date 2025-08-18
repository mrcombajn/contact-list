using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.Models;
using ContactList.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Functions.Query.GetContactList
{
    public class GetAllContactQueryHandler : IRequestHandler<GetAllContactQuery, List<Contact>>
    {

        private readonly ContactContext _context;

        public GetAllContactQueryHandler(ContactContext context)
        {
            this._context = context;
        }

        public Task<List<Contact>> Handle(GetAllContactQuery request, CancellationToken cancellationToken)
        {
            return _context.Contact.ToListAsync();
        }
    }
}
