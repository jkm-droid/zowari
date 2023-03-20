using Application.Boundary.Responses.Forums;
using Application.Features.Forum.Queries;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("forum")]
public class ForumController : Controller
{
    private readonly IMediator _mediator;

    public ForumController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Get all forums available
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<Result<List<ForumResponse>>>> Index()
    {
        var forums = await _mediator.Send(new GetAllForumsQuery());
        return View(forums);
    }
}