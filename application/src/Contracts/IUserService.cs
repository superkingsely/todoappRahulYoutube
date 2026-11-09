

public interface IUserService
{
    Task<bool> CreateUserAsync(CreateUserDto userDto);
}