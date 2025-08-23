using ContactList.Models.Entities;
using MediatR;

public sealed class GetContactQuery : IRequest<Contact>
{
    public Guid? Id { get; set; }
}