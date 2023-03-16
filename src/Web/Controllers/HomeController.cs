using System.Diagnostics;
using Application.Boundary.QueryParams;
using Application.Features.Topics.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zowari.Models;

namespace Zowari.Controllers;

public class HomeController : Controller
{
    private readonly IMediator _mediator;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IMediator mediator, ILogger<HomeController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index(TopicQueryParameters parameters)
    {
        //show list of available forums
        //show the latest topics
        var topicsResponse = await _mediator.Send(new GetAllTopicsQuery(parameters));
        return View(topicsResponse);
    }

    [HttpGet("latest-topics-list")]
    public async Task<IActionResult> LatestTopicsPartial(TopicQueryParameters parameters)
    {
        //show list of available forums
        //show the latest topics
        var topicsResponse = await _mediator.Send(new GetAllTopicsQuery(parameters));
        return PartialView("_LatestTopicsPartial", topicsResponse);
    }

    [Authorize]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}