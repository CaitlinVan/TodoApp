using TodoApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Console.Data;

public class ListRepository : IListRepository
{
    private readonly TodoDbContext _context; 
    
    public ListRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<TodoList?> GetByIdAsync(int id)
    {
        return await _context.List.FindAsync(id); 
    }

    public Task<List<TodoList>> GetAllAsync()
    {
        return _context.List.ToListAsync();
    }

    public async Task AddAsync(TodoList todoList)
    {
        _context.List.Add(todoList);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoList todoList)
    {
        _context.List.Update(todoList);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
       var list =  await _context.List.FindAsync(id);

       if (list != null)
       {
           _context.List.Remove(list);
           await _context.SaveChangesAsync();
       }
    }
    
}