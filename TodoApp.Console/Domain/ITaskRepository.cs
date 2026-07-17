using TodoApp.Console;

namespace TodoApp.Console.Domain;

public interface ITaskRepository
{
    Task<TodoTask?> GetByIdAsync(int id);
    Task<List<TodoTask>> GetAllAsync();
    Task AddAsync(TodoTask task);
    Task UpdateAsync(TodoTask  task);
    Task DeleteAsync(int id);
}