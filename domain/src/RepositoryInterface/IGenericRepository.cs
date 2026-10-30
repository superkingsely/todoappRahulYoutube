

// return tdomain to the application i.e the service layer

 public interface IGenericRepository<TDomain> where TDomain : class
    {
        Task<TDomain> GetByIdAsync(object id);

        Task<IEnumerable<TDomain>> GetAllAsync();

        Task AddAsync(TDomain domain);

        Task UpdateAsync(TDomain domain);

        Task<int> CommitAsync();

        // Task DetachAsync(object entityId);

    }