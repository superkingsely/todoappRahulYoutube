

using Microsoft.AspNetCore.Authentication;

public class UserContextMiddleware{

    private RequestDelegate _next;

    public UserContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token=await context.GetTokenAsync("access_token");
        if(string.IsNullOrEmpty(token))
        {
            await _next(context);
        }else
        {
            var CurrentUserId = GetUserIdFromToken(token);
            context.Request.Headers.Add("CurrentUserId", CurrentUserId.ToString());
            await _next(context);
        }
    }

    private Guid GetUserIdFromToken(string token)
    {
        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);
        var userId = jwtToken.Claims.FirstOrDefault(c => c.Type == "UserId")!.Value;
        return Guid.Parse(userId);
    }
}