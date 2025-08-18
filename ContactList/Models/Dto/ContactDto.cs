using System.ComponentModel.DataAnnotations;
using ContactList.Models.Entities;

namespace ContactList.Models.Dto
{
    public class ContactDto
    {
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

        public Category Category { get; set; }

        [MaxLength(20)]
        public SubCategory SubCategory { get; set; }

        [MaxLength(20)]
        public string PhoneNumebr { get; set; }

        public DateOnly BirthdayDate { get; set; }
    }
}
