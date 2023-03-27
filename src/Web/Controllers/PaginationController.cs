using Infrastructure.Shared.Paging;
using Microsoft.AspNetCore.Mvc;

namespace Zowari.Controllers
{
  [Route("pagination")]
  public class PaginationController : Controller
  {
    [HttpGet]
    public IActionResult Index([FromQuery] PagingMetaData pagingMeta)
    {
      return PartialView("_PagingPartial", pagingMeta);
    }
  }
}
