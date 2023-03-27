using Core.Application.Boundary.QueryParams;
using Core.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IActionResult> Index([FromQuery] CategoryQueryParameters parameters)
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
    public async Task<IActionResult> CategoriesPartial([FromQuery] CategoryQueryParameters parameters)
    {
        var categories = await _mediator.Send(new GetAllCategoriesQuery(parameters));
        return PartialView("_CategoriesPartial",categories);
    }
}