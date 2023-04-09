using Domain.Entities;

namespace Infrastructure.Extensions;

public static class RepositorySortExtensions
{
    public static IQueryable<Topic> SortTopicRecords(this IQueryable<Topic> topicRecords,
        string searchTerm)
    {
        return topicRecords.Where(topic =>
            (searchTerm == null ||
             topic.Body.ToLower().Contains(searchTerm.ToLower()) ||
             topic.Slug.ToLower().Contains(searchTerm.ToLower()) ||
             topic.Author.ToLower().Contains(searchTerm.ToLower())
            )
        );
    } 
}