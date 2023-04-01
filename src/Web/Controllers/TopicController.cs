using Core.Application.Boundary.Responses.Topics;
using Core.Application.Features.Topics.Queries;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers;

[Route("topic")]
public class TopicController : Controller
{
    private readonly IMediator _mediator;

    public TopicController(IMediator mediator)
    {
        _mediator = mediator;
    }
    /// <summary>
    /// Get single topic by its slug and id
    /// </summary>
    /// <param name="slug"></param>
    /// <param name="topicId"></param>
    /// <returns></returns>
    [HttpGet("/{topicId}/{slug}")]
    public async Task<ActionResult<Result<TopicResponse>>> Index([FromQuery]Guid topicId,string slug)
    {
        var topic = await _mediator.Send(new GetSingleTopicQuery(topicId, slug));
        return View(topic);
    }
    
}