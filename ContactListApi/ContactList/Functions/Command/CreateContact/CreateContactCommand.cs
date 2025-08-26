using ContactList.Abstractions.Messaging;

namespace ContactList.Functions.Command.CreateContact;

public sealed class CreateContactCommand : ICommand
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string Category { get; set; }
    public string SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthdayDate { get; set; }
}
