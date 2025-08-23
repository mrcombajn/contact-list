using ContactList.Abstractions.Messaging;

namespace ContactList.Functions.Command.DeleteContact;

public class DeleteContactCommand : ICommand
{
    public int Id { get; set; }
}
