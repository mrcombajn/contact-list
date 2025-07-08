using System.ComponentModel.DataAnnotations;

namespace ContactList.Repositories.Entities
{
    public class Contact
    {
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

        public Category Category { get; set; }

        [MaxLength(20)]
        public SubCategory SubCategory { get; set; }

        [MaxLength(20)]
        public string PhoneNumebr { get; set; }

        public DateOnly BirthdayDate { get; set; }
    }
}
