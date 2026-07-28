using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Console.Domain;
using System;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    [ObservableProperty] 
    private bool _isBoardView;
    
    public bool IsListView => !_isBoardView;
    
    [RelayCommand]
    private void ToggleView()
    {
        IsBoardView = !IsBoardView;
    }

    partial void OnIsBoardViewChanged(bool value)
    {
        OnPropertyChanged(nameof(IsListView));
    }
    
    
    public IEnumerable<TodoTask> NotDoneTasks =>
        Tasks.Where(t => !t.IsDone);

    public IEnumerable<TodoTask> DoneTasks =>
        Tasks.Where(t => t.IsDone);

    
    partial void OnTasksChanged(ObservableCollection<TodoTask> value)
    {
        foreach (var task in value)
        {
            task.PropertyChanged += OnTaskPropertyChanged;
        }

        OnPropertyChanged(nameof(NotDoneTasks));
        OnPropertyChanged(nameof(DoneTasks));
    }

    private void OnTaskPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TodoTask.IsDone))
        {
            OnPropertyChanged(nameof(NotDoneTasks));
            OnPropertyChanged(nameof(DoneTasks));
        }
    }
}