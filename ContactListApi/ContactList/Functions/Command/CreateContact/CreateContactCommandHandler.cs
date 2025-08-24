using ContactList.Abstractions.Messaging;
using ContactList.Abstractions.Shared;
using ContactList.Models;
using ContactList.Models.Dto;
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
        var category = _context.Category.Find(request.Category.Id);

        if (category is null)
            return Result.Failure<ContactDto>(Error.NullValue);

        var subCategory = _context
            .SubCategory
            .FirstOrDefault(e => e.Id == request.SubCategory.Id || e.Name.Equals(request.SubCategory.Name)) ??
            _context.SubCategory.Add(new() { Name = request.SubCategory.Name }).Entity;

        var contact = new Contact()
        {
            Email = request.Email,
            Name = request.Name,
            Surname = request.Surname,
            Password = request.Password,
            Category = category,
            SubCategory = subCategory,
            PhoneNumber = request.PhoneNumber,
            BirthdayDate = request.BirthdayDate,
        };

        try
        {
            var entry = _context.Contact.Add(contact).Entity;
            await _context.SaveChangesAsync();


            return Result.Success(new ContactDto()
            {
                Id = entry.Id,
                Email = entry.Email,
                Name = entry.Name,
                Surname = entry.Surname,
                Password = entry.Password,
                Category = new CategoryDto() { Id = entry.Category.Id, Name = entry.Category.Name },
                SubCategory = new SubCategoryDto { Id = entry.SubCategory.Id, Name = entry.SubCategory.Name },
                PhoneNumber = entry.PhoneNumber,
                BirthdayDate = entry.BirthdayDate,
            });
        }
        catch
        {
            return Result.Failure<ContactDto>(Error.NullValue);
        }
    }
}
