

public interface IUserRepository : IGenericRepository<UserDomain>
{
    Task<UserDomain> GetByEmailAsync(string emailAddress);
}