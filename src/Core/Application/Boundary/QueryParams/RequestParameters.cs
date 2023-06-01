namespace Core.Application.Boundary.QueryParams
{
  public abstract class RequestParameters
  {
    private const int MaxPageSize = 100;
    private int _pageSize = 10;
    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
      get => _pageSize;
      set => _pageSize = CalculatePageSize(value);
    }

    public string OrderBy { get; set; }

    private int CalculatePageSize(int value)
    {
      if (value <= 0)
      {
        return 1;
      }

      return value > MaxPageSize ? MaxPageSize : value;
    }
  }
}
