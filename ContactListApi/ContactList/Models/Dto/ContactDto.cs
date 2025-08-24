namespace ContactList.Models.Dto;

public class ContactDto
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public int Category { get; set; }
    public SubCategoryDto SubCategory { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthdayDate { get; set; }
}
