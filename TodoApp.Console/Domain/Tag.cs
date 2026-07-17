namespace TodoApp.Console.Domain;

public class Tag
{
    public int id { get; set; }
    public string name { get; set; } = string.Empty;

    public List<TodoTask> Tasks { get; set; } = new();
}