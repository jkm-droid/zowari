using Application.Boundary.Responses.Categories;

namespace Application.Boundary.Responses.Forums;

public class ForumResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
   
    public IList<CategoryResponse> CategoriesResponses { get; set; }
}