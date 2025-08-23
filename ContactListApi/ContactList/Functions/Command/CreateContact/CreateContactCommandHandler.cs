using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;

namespace ContactList.Functions.Command.CreateContact;

public sealed class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
{
    private ContactContext _context;

    public CreateContactCommandHandler(ContactContext context)
    { 
        _context = context;
    }

    public Task<Result> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
