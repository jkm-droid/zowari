using Domain.Entities;

namespace Infrastructure.Extensions
{
  public static class RepositoryFilterExtensions
  {
    public static IQueryable<Topic> FilterTopicRecords(this IQueryable<Topic> topicRecords,
      string searchTerm,string sortTerm)
    {
      var sortValues = new string[] {"today", "last_7_days", "last_14_days", "last_30_days", "last_month", "last_year"};
      DateTimeOffset sortDate;
      switch (sortValues.ToString()?.ToLower())
      {
        case "today":
          sortDate = DateTimeOffset.UtcNow.AddHours(-24);
          break;
        case "last_7_days":
          sortDate = DateTimeOffset.UtcNow.AddDays(-7);
          break;
        case "last_14_days":
          sortDate = DateTimeOffset.UtcNow.AddDays(-14);
          break;
        case "last_30_days":
          sortDate = DateTimeOffset.UtcNow.AddDays(-30);
          break;
        case "last_month":
          sortDate = DateTimeOffset.UtcNow.AddMonths(-1);
          break;
        case "last_year":
          sortDate = DateTimeOffset.UtcNow.AddYears(-1);
          break;
        default:
          sortDate = DateTimeOffset.UtcNow.AddYears(-2);
          break;
      }
      return topicRecords.Where(topic =>
        (searchTerm == null ||
         topic.Body.ToLower().Contains(searchTerm.ToLower()) ||
         topic.Slug.ToLower().Contains(searchTerm.ToLower()) ||
         topic.Author.ToLower().Contains(searchTerm.ToLower())
        )&&
        (sortTerm == null || topic.CreatedOn >= sortDate )
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
    public static IQueryable<Message> FilterMessageRecords(this IQueryable<Message> messages,
      string searchTerm)
    {
      return messages.Where(message =>
        (searchTerm == null ||
         message.Body.ToLower().Contains(searchTerm.ToLower()) ||
         message.Author.ToLower().Contains(searchTerm.ToLower())
        )
      );
    }
    
  }
}
