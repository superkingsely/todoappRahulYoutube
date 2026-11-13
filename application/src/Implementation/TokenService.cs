
using Microsoft.Extensions.Configuration;
using Todo.Application.Common;

public class TokenService(
        IUserRepository userRepository,
         IPasswordHasher passwordHasher,
         IConfiguration configuration
        //   IConfiguration configuration
        ) : ITokenService
{
     public async Task<Result<TokenResponseDto>> GetTokenAsync(TokenRequestDto requestDto)
        {
            var userDomain =
                await userRepository.GetByEmailAsync(requestDto.userName);

            if (userDomain == null)
                return Result.Failure<TokenResponseDto>(
                    Error.Unauthorized("Auth.InvalidEmail", ErrorConstants.InvalidEmail));

            if (!passwordHasher.VerifyPassword(requestDto.password, userDomain.PasswordHash))
                return Result.Failure<TokenResponseDto>(
                    Error.Unauthorized("Auth.InvalidPassword", ErrorConstants.InvalidPassword));
            
            // Generate refresh token
            var refreshToken = 
                await GenerateAndStoreRefreshTokenAsync(userDomain.Id, clientIp: null);

            // Generate access token
            string accessToken = GenerateAccessToken(userDomain, refreshToken.refreshTokenId);
            int accessTokenExpiryMinutes = GetAccessTokenExpiryMinutes();

            return Result.Success(new TokenResponseDto(accessToken, refreshToken.refreshToken));
        }


         private string GenerateAccessToken(UserDomain userResponse, Guid sessionId)
        {
            string secretKey = configuration["Jwt:Secret"]!;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            int expiryMinutes = GetAccessTokenExpiryMinutes();

            var tokenDescriptor
                = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity([
                        new Claim(ClaimTypes.Name, userResponse.FullName),
                        new Claim(ClaimTypes.Email, userResponse.Email),
                        new Claim("UserId", userResponse.Id.ToString()),
                        new Claim("sid",sessionId.ToString())
                    ]),
                    Expires = DateTime.UtcNow.AddMinutes(expiryMinutes),
                    SigningCredentials = credentials,
                    Issuer = configuration["Jwt:Issuer"],
                    Audience = configuration["Jwt:Audience"]
                };

            var tokenHandler = new JsonWebTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return token;
        }



}