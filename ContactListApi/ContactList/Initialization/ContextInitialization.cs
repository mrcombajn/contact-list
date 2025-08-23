using ContactList.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactList.Initialization;

public static class ContextInitialization
{

    public static void InitializeData(ContactContext context)
    {
        context.Database.Migrate();

        if (!context.Category.Any())
        {
            context.Category.Add(new() { Name = "służbowy" });
            context.Category.Add(new() { Name = "prywatny" });
            context.Category.Add(new() { Name = "inny" });
        }

        if (!context.SubCategory.Any())
        {
            context.SubCategory.Add(new() { Name = "szef" });
            context.SubCategory.Add(new() { Name = "klient" });
        }

        context.SaveChangesAsync();
    }
}
