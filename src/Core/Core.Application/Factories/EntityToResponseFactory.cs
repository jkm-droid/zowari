using Core.Application.Boundary.Responses;
using Core.Application.Boundary.Responses.Categories;
using Core.Application.Boundary.Responses.Forums;
using Core.Application.Boundary.Responses.Messages;
using Core.Application.Boundary.Responses.Topics;
using Domain.Entities;
using Infrastructure.Abstractions;

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
            TopicId = topic.Id,
            Title = topic.Title,
            Body = topic.Body,
            Slug = topic.Slug,
            AuthorResponse = new AuthorResponse
            {
                UserId = topic.User.Id,
                AuthorName = topic.User.UserName,
                ProfileUrl = topic.User.ProfileUrl,
                Score = topic.User.Score,
                Rating = topic.User.Rating,
                Level = topic.User.Level
            },
            TopicStats = new TopicStatsResponse
            {
                CategoryName = topic.Category.Title ?? string.Empty,
                Replies = topic.Messages.Count,
                Views = topic.Views,
                LastActivity = default
            },
            CreatedOn = topic.CreatedOn.ToString("dd MMM yyyy HH:mm tt")
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

    public static IQueryable<MessageResponse> ToMessageResponse(this IQueryable<Message> messages)
    {
        return messages.Select(m => new MessageResponse
        {
            Id = m.Id,
            Body = m.Body,
            Author = m.Author,
            CreatedOn = m.CreatedOn.ToString("dd MMM yyyy"),
            CommentsResponses = null,
            BookmarksResponses = null,
            LikesResponses = null
        });
    }

}