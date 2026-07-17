namespace TodoApp.Console.Domain;

public interface IListRepository
{
    Task<TodoList?> GetByIdAsync(int id);
    Task<List<TodoList>> GetAllAsync();
    Task AddAsync(TodoList list);
    Task UpdateAsync(TodoList list);
    Task DeleteAsync(int id);
}