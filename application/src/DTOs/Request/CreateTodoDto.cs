

public record CreateTodoDto(
    string name,
    string description,
    List<CreateTodoItemsDto> Items);