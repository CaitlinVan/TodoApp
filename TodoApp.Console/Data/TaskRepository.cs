using TodoApp.Console.Domain;
using Microsoft.EntityFrameworkCore;

namespace TodoApp.Console.Data;

public class TaskRepository : ITaskRepository
{
    private readonly TodoDbContext _context;

    public TaskRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<TodoTask?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<List<TodoTask>> GetAllAsync()
    {
        return await _context.Tasks.Include("List").ToListAsync();
    }

    public async Task AddAsync(TodoTask task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateAsync(TodoTask task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if(task is not null)
        {
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
    
    //Primarily Async I/Os
}