using Domain.Entities;

namespace Infrastructure.Extensions
{
  public static class RepositoryFilterExtensions
  {
    public static IQueryable<Topic> FilterTopicRecords(this IQueryable<Topic> topicRecords,
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
    public static IQueryable<Category> FilterCategoryRecords(this IQueryable<Category> categories,
      string searchTerm)
    {
      return categories.Where(category =>
        (searchTerm == null ||
         category.Title.ToLower().Contains(searchTerm.ToLower()) ||
         category.Slug.ToLower().Contains(searchTerm.ToLower()) ||
         category.Description.ToLower().Contains(searchTerm.ToLower())
        )
      );
    }
    
  }
}
