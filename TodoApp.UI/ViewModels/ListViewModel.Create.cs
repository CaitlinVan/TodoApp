using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TodoApp.Console.Domain;
using System.Threading.Tasks;
using System;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    //Add List

    [ObservableProperty] private string _newListName = string.Empty;

    [RelayCommand]
    private async Task AddList()
    {
        if (string.IsNullOrWhiteSpace(_newListName))
        {
            return;
        }

        var list = new TodoList
        {
            Name = _newListName,
            CreatedAt = DateTime.UtcNow,
        };
        
        await _listRepository.AddAsync(list);
        
        NewListName = string.Empty;
        await LoadListsAsync();

    }

}