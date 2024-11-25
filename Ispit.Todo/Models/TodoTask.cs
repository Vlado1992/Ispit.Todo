namespace Ispit.Todo.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; } 
        public int TodoListId { get; set; }
        public TodoList TodoList { get; set; }
    }
}
