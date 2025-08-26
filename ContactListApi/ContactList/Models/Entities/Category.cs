using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Entities;

public class Category
{
    [Key]
    [Required]
    public string Name { get; set; }

}
