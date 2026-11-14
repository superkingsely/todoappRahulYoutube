

public record CreateTodoItemsDto(
    string title,
    string description,
    TodoPriority priority,
    DateTime dueDate,
    DateTime remiderDate
    );