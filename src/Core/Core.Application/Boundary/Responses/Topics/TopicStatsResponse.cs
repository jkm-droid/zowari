namespace Core.Application.Boundary.Responses.Topics;

public class TopicStatsResponse
{
    public int Replies { get; set; }
    public int Views { get; set; }
    public string LastActivity { get; set; }
}