

  public static class UserMappingExtension
    {
        extension(CreateUserDto user)
        {
            public UserDomain ToUserDomain()
            {
                return new UserDomain()
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    PasswordHash = user.Password
                };
            }
        }
    }