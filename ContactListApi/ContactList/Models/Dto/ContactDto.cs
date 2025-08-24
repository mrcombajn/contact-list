namespace ContactList.Models.Dto;

public class ContactDto
{
    public int? Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public CategoryDto Category { get; set; }
    public SubCategoryDto SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthdayDate { get; set; }
}
