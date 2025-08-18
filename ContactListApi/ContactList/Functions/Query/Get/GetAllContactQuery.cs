using ContactList.Models.Entities;
using MediatR;

namespace ContactList.Functions.Query.GetContactList
{
    public class GetAllContactQuery : IRequest<List<Contact>>
    {
    }
}
