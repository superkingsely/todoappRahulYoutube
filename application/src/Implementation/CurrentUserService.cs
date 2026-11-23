

using Microsoft.AspNetCore.Http;
using System.Security.Claims;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext.Request.Headers["CurrentUserId"];
        if (string.IsNullOrEmpty(userId))
        {
            // throw new Exception("User is not authenticated.");
            return string.Empty;
            // return string.Empty; // or throw an exception, depending on your use case
        }
        return userId;
    }

    // public string GetCurrentUserName()
    // {
    //     var userId = _httpContextAccessor.HttpContext.Request.Headers["CurrentUserId"];
    //     if (string.IsNullOrEmpty(userId))
    //     {
    //         // throw new Exception("User is not authenticated.");
    //         return string.Empty;
    //         // return string.Empty; // or throw an exception, depending on your use case
    //     }

    //     throw new NotImplementedException();
    // }
}