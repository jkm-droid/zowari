using Core.Application.Boundary.QueryParams;
using Core.Application.Features.Categories.Queries;
using Core.Application.Features.Topics.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Zowari.Models.ViewModels;

namespace Zowari.Controllers;

[Route("categories")]
public class CategoriesController : Controller
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <summary>
    /// Get all categories
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> Index(CategoryQueryParameters parameters)
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery(parameters));
        return View(categories);
    }

    /// <summary>
    /// Get paginated categories async
    /// </summary>
    /// <param name="parameters"></param>
    /// <returns></returns>
    [HttpGet("categories-list")]
    public async Task<IActionResult> CategoriesPartial(CategoryQueryParameters parameters)
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery(parameters));
        return PartialView("_CategoriesPartial",categories);
    }

    /// <summary>
    /// Get a category by it's id
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="slug"></param>
    /// <returns></returns>
    [HttpGet("{categoryId}/{slug}")]
    public async Task<ActionResult> Category(string categoryId,string slug)
    {
        //get category
        var category = await _mediator.Send(new GetCategoryByIdQuery(categoryId, slug));
        //get all topics owned by the category
        var categoryTopics =
            await _mediator.Send(new GetTopicByCategoryIdQuery(new TopicQueryParameters(), categoryId));

        var response = new CategoryTopicViewModel
        {
            CategoryResponse = category.Data,
            TopicResponse = categoryTopics.Data
        };
        return View(response);
    }
}