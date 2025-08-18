using ContactList.Models.Entities;
using MediatR;

public class GetContactQuery : IRequest<Contact>
{
    public Guid? Id { get; set; }
}