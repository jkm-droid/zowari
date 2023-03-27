using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("topic")]
public class TopicController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
}