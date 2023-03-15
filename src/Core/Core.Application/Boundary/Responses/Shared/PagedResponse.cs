using Application.Boundary.QueryParams;

namespace Application.Boundary.Responses.Shared
{
  public class PagedResponse<TResponse>
  {
    public PagingMetaData PagingMetaData { get; set; }

    public IEnumerable<TResponse> Data { get; set; }
  }
}
