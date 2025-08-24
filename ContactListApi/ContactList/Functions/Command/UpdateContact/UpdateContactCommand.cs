using ContactList.Abstractions.Messaging;
using ContactList.Models.Dto;

namespace ContactList.Functions.Command.UpdateContact;

public sealed class UpdateContactCommand : ICommand
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public int Category { get; set; }
    public SubCategoryDto SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthdayDate { get; set; }
}