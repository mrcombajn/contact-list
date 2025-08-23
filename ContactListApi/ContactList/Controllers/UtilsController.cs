using ContactList.Models;
using ContactList.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactList.Controllers;

[Controller]
[Route("/api/utils")]
public class UtilsController : ControllerBase
{
    private ContactContext _context;

    public UtilsController(ContactContext context)
    {
        _context = context;
    }

    [HttpGet]
    public List<Category> GetCategories()
    {
        return _context.Category.ToList();
    }

}
