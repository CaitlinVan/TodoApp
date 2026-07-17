namespace TodoApp.Console.Domain;

public class TodoList
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public List<TodoTask> Tasks { get; set; } = new();
    
}