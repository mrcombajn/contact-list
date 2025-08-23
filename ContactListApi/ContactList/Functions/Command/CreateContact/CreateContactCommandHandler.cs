using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;
using ContactList.Models.Entities;

namespace ContactList.Functions.Command.CreateContact;

public sealed class CreateContactCommandHandler : ICommandHandler<CreateContactCommand>
{
    private ContactContext _context;

    public CreateContactCommandHandler(ContactContext context)
    { 
        _context = context;
    }

    public async Task<Result> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = new Contact()
        {
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname,
            Password = request.Password,
            Category = request.Category,
            SubCategory = request.SubCategory,
            PhoneNumber = request.PhoneNumber,
            BirthdayDate = request.BirthdayDate,
        };

        try
        {
            _context.Contact.Add(contact);

            _context.SaveChangesAsync();

            return Result.Success();
        }
        catch (Exception ex)
        {

            return Result.Failure(Error.NullValue);
        }
    }
}
