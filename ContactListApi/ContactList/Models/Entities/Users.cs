using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Entities;

public class Users
{
    int Id { get; set; }

    [Required]
    public string Username;

    [Required]
    public string Password { get; set; }
}
