namespace TodoApp.Console.Domain;

public class TodoTask
{
    public int Id { get; set; }
    public int? ListId { get; set; }
    public string Title { get; set; } =  string.Empty;
    public string? Description { get; set; }
    public bool IsDone { get; set; } 
    public int? Priority { get; set; }
    public bool IsPinned { get; set; }
    public string? Color { get; set; }
    public DateOnly? due_date { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public TodoList? List { get; set; }
    public List<Tag> Tags { get; set; }
    
}