using CommunityToolkit.Mvvm.ComponentModel;
using TodoApp.Console.Domain;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    //Collection + LoadListsAsync (Reading)
    
    private readonly IListRepository _listRepository;

    [ObservableProperty] 
    private ObservableCollection<TodoList> _lists = new();

    [RelayCommand]
    private async Task RenameList(TodoList list)
    {
        await _listRepository.UpdateAsync(list);
    }

    private async Task LoadListsAsync()
    {
        var lists= await _listRepository.GetAllAsync();
        Lists = new ObservableCollection<TodoList>(lists);
    }
    

}