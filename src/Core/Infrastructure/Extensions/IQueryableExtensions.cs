using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Extensions
{
  public static class QueryableExtensions
  {
    public static IQueryable<T> GetPage<T>(this IQueryable<T> list, int pageNumber, int pageSize)
    {
      return list
          .Skip((pageNumber - 1) * pageSize)
          .Take(pageSize);
    }

    public static IQueryable<T> TrackChanges<T>(this IQueryable<T> list, bool trackChanges = false) where T : class
    {
      if (trackChanges)
      {
        return list;
      }

      return list
          .AsNoTracking();
    }
  }
}
