namespace Infrastructure.Shared.Abstractions;

public interface IViewRenderService
{
    Task<string> RenderToStringAsync(string viewName, object model);
}