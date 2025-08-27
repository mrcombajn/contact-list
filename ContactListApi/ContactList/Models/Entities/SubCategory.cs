using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Entities;

public class SubCategory
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

}
