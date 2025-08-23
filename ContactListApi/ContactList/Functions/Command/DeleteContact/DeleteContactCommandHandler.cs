using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;

namespace ContactList.Functions.Command.DeleteContact;

public class DeleteContactCommandHandler : ICommandHandler<DeleteContactCommand>
{
    private ContactContext _context;

    public DeleteContactCommandHandler(ContactContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contact.FindAsync(request.Id);

        if (contact == null)
            return Result.Failure(Error.NullValue);

        _context.Contact.Remove(contact);
        await _context.SaveChangesAsync();

        return Result.Success();
    }
}
