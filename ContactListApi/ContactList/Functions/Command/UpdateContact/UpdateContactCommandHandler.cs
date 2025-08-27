
using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;
using ContactList.Models.Dto;
using Microsoft.EntityFrameworkCore;

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

        var category = await _context.Category.FirstOrDefaultAsync(u => u.Name == request.Category);

        if (category is null)
            return Result.Failure<ContactDto>(Error.NullValue);

        var subCategory = await _context
            .SubCategory
            .FirstOrDefaultAsync(u => u.Name == request.Category) ??
            _context.SubCategory.Add(new() { Name = request.SubCategory }).Entity;

        contact.Email = request.Email;
        contact.Name = request.Name;
        contact.Surname = request.Surname;
        contact.Password = request.Password;
        contact.Category = category;
        contact.SubCategory = subCategory;
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
