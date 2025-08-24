using ContactList.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Models;

public class UsersContext : DbContext
{
    public UsersContext(DbContextOptions<ContactContext> options)
    : base(options)
    {
    }

    public DbSet<Users> Users { get; set; }

}
