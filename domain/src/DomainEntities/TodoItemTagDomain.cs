

public class TodoItemTag
{
    public string Id { get; set; } = $"Tag-{Guid.NewGuid()}";
    public Guid TodoItemId { get; set; }
    public TodoItemDomain? TodoItem { get; set; }

    public Guid TagId { get; set; }
    public TagDomain? Tag { get; set; }
}