using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Console.Domain;
using System.Threading.Tasks;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    //AddTaskCommand

    [ObservableProperty] 
    private string _newTaskTitle = String.Empty;
    
    [ObservableProperty]
    private TodoList? _selectedList;
    
    [ObservableProperty]
    private string _newTaskDescription = String.Empty;
    
    [ObservableProperty]
    private int? _newTaskPriority;
    
    [RelayCommand]
    private async Task AddTask()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle))
        {
            return; 
        } 
        
        var task = new TodoTask()
        {
            Title = NewTaskTitle,
            CreatedAt = DateTime.UtcNow,
            ListId = SelectedList?.Id,
            Priority = _newTaskPriority is null or -1 ? null : _newTaskPriority, 
        }; 
        
        await _taskRepository.AddAsync(task);
        
        NewTaskTitle = String.Empty;
        NewTaskDescription = String.Empty;
        NewTaskPriority = null;
        await LoadTasksAsync();
        
    }

}