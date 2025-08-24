using ContactList.Models.Entities;
using MediatR;

namespace ContactList.Functions.Query.GetAllContact;

public sealed class GetAllContactQuery : IRequest<IEnumerable<Contact>>
{
}
