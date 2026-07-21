using TodoApp.Console.Data;
using TodoApp.Console.Domain; 
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;

namespace TodoApp.UI.ViewModels;

//Constructor, Tasks Property, LoadTasksAsync

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ITaskRepository _taskRepository;
    
    [ObservableProperty]
    private ObservableCollection<TodoTask> _tasks = new();

    public MainWindowViewModel()
    {
        _taskRepository = new TaskRepository(new TodoDbContext());
        _listRepository = new ListRepository(new TodoDbContext());
        _ = LoadTasksAsync(); 
        _ = LoadListsAsync();
    }

    private async Task LoadTasksAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
        Tasks = new ObservableCollection<TodoTask>(tasks);
    }
    
}
