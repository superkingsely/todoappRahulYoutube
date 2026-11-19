
public interface ITodoRepository : IGenericRepository<TodoListDomain>
{
    Task<List<TodoListDomain>> GetTodosAsync(Guid userId);
}