
using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;

namespace ContactList.Functions.Command.UpdateContact;

public sealed class UpdateContactCommandHandler : ICommandHandler<UpdateContactCommand>
{
    private ContactContext _context;

    public UpdateContactCommandHandler(ContactContext context)
    {
        _context = context;
    }

    public async Task<Result> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contact.FindAsync(request.Id);

        if (contact == null)
            return Result.Failure(Error.NullValue);

        contact.Email = request.Email;
        contact.Name = request.Name;
        contact.Surname = request.Surname;
        contact.Password = request.Password;

        //wyszukiwanie tych kategorii trzeba zrobić tak samo jak przy dodawaniu kontaktu
        //contact.Category = _context.Category.Find(request.Category);
        //contact.SubCategory = _context.SubCategory.Find(request.SubCategory);
        contact.PhoneNumber = request.PhoneNumber;
        contact.BirthdayDate = request.BirthdayDate;

        try
        {
            await _context.SaveChangesAsync();
            return Result.Success(contact);
        }
        catch (Exception ex)
        {
            return Result.Failure(Error.NullValue);
        }
    }
}
