

 public class UserMappingExtension : Profile
    {

        public UserMappingExtension()
        {
            CreateMap<User, UserDomain>().ReverseMap();  // entity --> domaiin

            
        }
    }