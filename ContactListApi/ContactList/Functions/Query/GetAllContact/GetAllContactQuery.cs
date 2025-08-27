using ContactList.Models.Dto;
using MediatR;

namespace ContactList.Functions.Query.GetAllContact;

public sealed class GetAllContactQuery : IRequest<IEnumerable<DummyContactDto>>
{
}
