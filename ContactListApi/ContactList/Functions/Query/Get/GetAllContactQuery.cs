using ContactList.Models.Entities;
using MediatR;

namespace ContactList.Functions.Query.Get
{
    public class GetContactQuery : IRequest<List<Contact>>
    {
        public Guid? Id { get; set; }
    }
}
