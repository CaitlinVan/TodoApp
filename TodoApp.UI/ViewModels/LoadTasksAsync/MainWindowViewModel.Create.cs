using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Console.Domain;

namespace TodoApp.UI.ViewModels.LoadTasksAsync;

public class MainWindowViewModel_Create
{
    //AddTaskCommand

    [ObservableProperty] 
    private string newTaskTitle = String.Empty;

    [RelayCommand]
    private async void AddTask()
    {
        if (string.IsNullOrWhiteSpace(newTaskTitle))
        {
            return; 
        } 
        
        var task = new TodoTask()
        {
            Title = newTaskTitle,
            CreatedAt = DateTime.UtcNow
        }; 
        
        await _taskRepository.AddAsync(task);
        
        newTaskTitle = String.Empty;
        await LoadTasksAsync();
        
    }

   




}