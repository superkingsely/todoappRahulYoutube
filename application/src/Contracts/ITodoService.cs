

using Todo.Application.Common;

public interface ITodoService
    {
        Task<Result> CreateTodoAsync(CreateTodoDto todos);

        Task<Result<List<TodoResponseDto>>> GetItems();
    }