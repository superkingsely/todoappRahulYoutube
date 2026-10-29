
 public class TodoItemTag
    {
        public Guid Id { get; set; }=$"Tag-{Guid.NewGuid()}";
        public Guid TodoItemId { get; set; }
        public TodoItem TodoItem { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }