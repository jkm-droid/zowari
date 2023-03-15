namespace Application.Boundary.QueryParams
{
  public class PagedList<T> : List<T>
  {
    public PagedList(List<T> items, int count, int pageNumber, int pageSize)
    {
      MetaData = new PagingMetaData
      {
        TotalCount = count,
        PageSize = pageSize,
        CurrentPage = pageNumber,
        TotalPages = (int)Math.Ceiling(count / (double)pageSize)
      };
      AddRange(items);
    }

    public PagingMetaData MetaData { get; set; }

    public static PagedList<T> ToPagedList(List<T> source, int pageNumber, int pageSize)
    {
      int count = source.Count();
      var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

      return new PagedList<T>(items, count, pageNumber, pageSize);
    }
  }
}
