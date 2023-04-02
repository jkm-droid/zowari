using Core.Application.Boundary.QueryParams;
using Core.Application.Boundary.Responses.Topics;
using Core.Application.Features.Messages;
using Core.Application.Features.Topics.Queries;
using Infrastructure.Shared.Wrapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zowari.Models.ViewModels;

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
    [HttpGet("{topicId:guid}/{slug}")]
    public async Task<ActionResult<Result<TopicResponse>>> Index(Guid topicId,string slug)
    {
        //get the topic
        var topic = await _mediator.Send(new GetSingleTopicQuery(topicId, slug));
        //get all messages belonging to the topic
        var messages = await _mediator.Send(new GetMessagesByTopicIdQuery(topicId, new MessageQueryParameters()));

        var topicMessageResponse = new TopicMessageViewModel
        {
            TopicResponse = topic.Data,
            MessageResponse = messages.Data
        };
        
        return View(topicMessageResponse);
    }

    /// <summary>
    /// Get messages by topic id
    /// </summary>
    /// <param name="topicId"></param>
    /// <param name="queryParameters"></param>
    /// <returns></returns>
    [HttpGet("topic-messages")]
    public async Task<ActionResult> TopicMessagesPartial(Guid topicId,[FromQuery] MessageQueryParameters queryParameters)
    {
        var topicMessages = await _mediator.Send(new GetMessagesByTopicIdQuery(topicId, queryParameters));
        var response = new TopicMessageViewModel
        {
            MessageResponse = topicMessages.Data
        };
        
        return View("_TopicMessagesPartial",response);
    }
    
}