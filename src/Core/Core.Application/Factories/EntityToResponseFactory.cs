using Application.Boundary.Responses.Categories;
using Application.Boundary.Responses.Forums;
using Application.Boundary.Responses.Topics;
using Domain.Entities;

namespace Application.Factories;

public static class EntityToResponseFactory
{
    public static IQueryable<ForumResponse> ToForumLists(this IQueryable<ForumList> forumLists)
    {
        return forumLists.Select(fl => new ForumResponse
        {
            Id = fl.Id,
            Title = fl.Title,
            Description = fl.Description,
            CategoriesResponses = null
        });
    }

    public static IQueryable<TopicResponse> ToTopicResponse(this IQueryable<Topic> topics)
    {
        return topics.Select(topic => new TopicResponse
        {
            Id = topic.Id,
            Body = topic.Body,
            Author = topic.Author,
            Slug = topic.Slug,
            MessagesResponses = null,
            BookmarksResponses = null
        });
    }
}