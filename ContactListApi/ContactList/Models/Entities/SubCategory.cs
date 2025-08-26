using System.ComponentModel.DataAnnotations;

namespace ContactList.Models.Entities;

public class SubCategory
{

    [Key]
    [Required]
    public string Name { get; set; }

}
