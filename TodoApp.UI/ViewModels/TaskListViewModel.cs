using System.Collections.ObjectModel;
using TodoApp.Console.Domain;

namespace TodoApp.UI.ViewModels;

public class TaskListViewModel
{
    public ObservableCollection<TodoTask> Tasks { get; set; } = new();
    
    private readonly ITaskRepository _repository;

    public TaskListViewModel(ITaskRepository repository)
    {
        _repository =  repository;
    }

    public async Task LoadTasksAsync()
    {
        var tasks = await _repository.GetAllAsync();
        Tasks =  new ObservableCollection<TodoTask>(tasks);
    }
}