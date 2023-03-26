using Core.Application.Boundary.Responses;
using Core.Application.Boundary.Responses.Forums;
using Core.Application.Boundary.Responses.Topics;
using Domain.Entities;

namespace Core.Application.Factories;

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
            AuthorResponse = new AuthorResponse
            {
                UserId = topic.User.Id,
                AuthorName = topic.User.UserName,
                ProfileUrl = topic.User.ProfileUrl,
                Score = topic.User.Score,
                Rating = topic.User.Rating,
                Level = topic.User.Level
            },
            Slug = topic.Slug,
            CreatedOn = topic.CreatedOn,
            MessagesResponses = null,
            BookmarksResponses = null
        });
    }
}