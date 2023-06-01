namespace Infrastructure.Shared.Paging
{
  public class PagedResponse<TResponse>
  {
    public PagingMetaData PagingMetaData { get; set; }

    public IEnumerable<TResponse> Data { get; set; }
  }
}
