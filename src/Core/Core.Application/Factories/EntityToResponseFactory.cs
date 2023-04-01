using Core.Application.Boundary.Responses;
using Core.Application.Boundary.Responses.Categories;
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
            TopicStats = new TopicStatsResponse
            {
                Replies = topic.Messages.Count,
                Views = topic.Views,
                LastReplyDate = default
            },
            CreatedOn = topic.CreatedOn
        });
    }

    public static IQueryable<CategoryResponse> ToCategoryResponse(this IQueryable<Category> categories)
    {
        return categories.Select(c => new CategoryResponse
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            Slug = c.Slug,
            TopicCount = c.Topics.Count,
            TopicsResponses = null,
            ForumId = default
        });
    }

    public static TopicResponse TopicResponse(this Topic topic)
    {
        return new TopicResponse
        {
            Id = default,
            Body = null,
            AuthorResponse = null,
            TopicStats = null,
            Slug = null,
            CreatedOn = default
        };
    }
}