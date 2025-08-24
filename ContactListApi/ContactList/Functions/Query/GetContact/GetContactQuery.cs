using ContactList.Models.Dto;
using MediatR;

public sealed class GetContactQuery : IRequest<ContactDto>
{
    public int Id { get; set; }
}