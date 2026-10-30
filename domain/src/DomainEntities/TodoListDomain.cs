

public class TodoListDomain
{
    public Guid Id { get; set; }
    public string Name { get; set; }="";
    public string Description { get; set; }="";
    public ICollection<TodoItemDomain> TodoItems { get; set; }=new List<TodoItemDomain>();
    public Guid UserId { get; set; }
    public UserDomain? User { get; set; }
}