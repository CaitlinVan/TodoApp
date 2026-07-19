using TodoApp.Console.Data;
using TodoApp.Console.Domain; 
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly ITaskRepository _taskRepository;
    
    [ObservableProperty]
    private ObservableCollection<TodoTask> _tasks = new();

    public MainWindowViewModel()
    {
        
    }
    
    
}
