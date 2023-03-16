using Application.Features.Test.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

public class TestController : Controller
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var response = await _mediator.Send(new GenerateFakeDataCommand());
        return View(response);
    }
}