namespace ContactList.Repositories.Entities
{
    public class Contact
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string PhoneNumebr { get; set; }

        public DateOnly BirthDay { get; set; }
    }
}
