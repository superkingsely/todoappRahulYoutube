

using Todo.Application.Common;

public interface ITokenService
{
    
    Task<Result<TokenResponseDto>> GetTokenAsync(TokenRequestDto requestDto);

    // Task<Result<TokenResponseDto>> RefreshTokenAsync(
    //     RefreshTokenRequestDto requestDto, string? clientIp = null);

    // Task<Result> RevokeTokenAsync(string refreshToken, string? clientIp = null);

    // Task<bool> RevokeAllUserTokensAsync(Guid userId, string? clientIp = null);
}