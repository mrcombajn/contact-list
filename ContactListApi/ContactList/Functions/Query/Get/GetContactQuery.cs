using ContactList.Models.Entities;
using MediatR;

public class GetContactQuery : IRequest<List<Contact>>
{
    public Guid? Id { get; set; }
}