namespace Core.Application.Boundary.QueryParams;

public class TopicQueryParameters : RequestParameters
{
  public string SearchTerm { get; set; }
  public string SortTerm { get; set; }
}