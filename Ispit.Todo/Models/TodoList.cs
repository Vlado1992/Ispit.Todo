namespace Ispit.Todo.Models
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<TodoTask> Tasks { get; set; } = new List<TodoTask>();
    }
}
