using ContactList.Models.Entities;
using MediatR;

namespace ContactList.Functions.Query.Get
{
    public class GetAllContactQuery : IRequest<List<Contact>>
    {
    }
}
