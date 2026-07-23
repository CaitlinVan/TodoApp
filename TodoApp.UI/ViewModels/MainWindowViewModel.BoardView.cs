using System.Collections.Generic;
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
        OnPropertyChanged(nameof(NotDoneTasks));
        OnPropertyChanged(nameof(DoneTasks));
    }
}