

public static class ConvertToTodoListDomainClass
{
    public static TodoListDomain ConvertToTodoListDomain(this CreateTodoDto createTodoDto)
    {
        return new TodoListDomain()
        {
            Description = createTodoDto.description,
            Name = createTodoDto.name,
            TodoItems = createTodoDto.Items.Select(x => new TodoItemDomain()
            {
                Description = x.description,
                Title = x.title,
                Priority = x.priority,
                DueDate = x.dueDate,
                ReminderDate = x.remiderDate,
            })
               .ToList()
        };
    }
    public static TodoResponseDto ToResponseDto(this TodoListDomain source) =>
           new TodoResponseDto(
               Name: source.Name,
               Description: source.Description,
               Metadata: source.TodoItems
                   .Select(item => item.ToMetadata())
                   .ToList()
           );

    public static TodoMetadata ToMetadata(this TodoItemDomain source) =>
   new(
       Title: source.Title,
       Description: source.Description,
       Priority: source.Priority.ToString(),
       Status: source.Status.ToString(),
       DueDate: source.DueDate
   );

    public static List<TodoResponseDto> ToResponseDtos(this IEnumerable<TodoListDomain> source) =>
            source.Select(todo => todo.ToResponseDto()).ToList();
}