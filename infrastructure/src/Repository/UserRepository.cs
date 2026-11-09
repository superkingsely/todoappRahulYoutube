

using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class UserRepository : GenericRepository<UserDomain, User>, IUserRepository
    {
        public UserRepository(
            TodoAppDbContext todoAppDbContext, 
            IMapper _mapper) : base(todoAppDbContext, _mapper)
        {

        }

        public async Task<UserDomain> GetByEmailAsync(
            string emailAddress)
        {

            var user = 
                await _todoAppDbContext.Users.FirstOrDefaultAsync(
                        x => x.Email == emailAddress);

            return _mapper.Map<UserDomain>(user);
        }
    }