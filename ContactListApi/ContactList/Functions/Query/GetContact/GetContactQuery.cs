using ContactList.Models.Entities;
using MediatR;

public sealed class GetContactQuery : IRequest<Contact>
{
    public int Id { get; set; }
}