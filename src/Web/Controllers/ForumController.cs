using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("forum")]
public class ForumController : Controller
{
    [HttpGet]
    public IActionResult ForumListAsync()
    {
        return View();
    }
}