using System.Diagnostics;
using Core.Application.Boundary.QueryParams;
using Core.Application.Features.Forum.Queries;
using Core.Application.Features.Topics.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zowari.Models;
using Zowari.Models.ViewModels;

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
        //show the latest topics
        var topicsResponse = await _mediator.Send(new GetAllTopicsQuery(parameters));
        //show list of available forums
        var forumsResponse = await _mediator.Send(new GetAllForumsQuery());

        var latestTopicsForums = new LatestTopicsForumsViewModel
        {
            TopicResponse = topicsResponse.Data,
            ForumResponse = forumsResponse.Data
        };
        return View(latestTopicsForums);
    }

    [HttpGet("forums-list")]
    public async Task<IActionResult> ForumListPartial()
    {
        //show all forums in partial view
        var forumsResponse = await _mediator.Send(new GetAllForumsQuery());
        var forums = new LatestTopicsForumsViewModel
        {
            ForumResponse = forumsResponse.Data
        };
        return PartialView("_ForumsListPartial", forums);
    }
    
    [HttpGet("latest-topics-list")]
    public async Task<IActionResult> LatestTopicsPartial(TopicQueryParameters parameters)
    {
        //show the latest topics in partial view
        var topicsResponse = await _mediator.Send(new GetAllTopicsQuery(parameters));
        var latestTopics = new LatestTopicsForumsViewModel
        {
            TopicResponse = topicsResponse.Data
        };
        return PartialView("_LatestTopicsPartial", latestTopics);
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