using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ContactList.Models.Entities;

public class Contact
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Email { get; set; }

    [Required]
    [MaxLength(20)]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string Surname { get; set; }


    [MaxLength(20)]
    public string Password { get; set; }

    [AllowNull]
    public Category Category { get; set; }

    [AllowNull]
    public SubCategory SubCategory { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    public DateOnly BirthdayDate { get; set; }
}
