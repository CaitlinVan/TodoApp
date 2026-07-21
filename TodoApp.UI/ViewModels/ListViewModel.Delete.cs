using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TodoApp.Console.Domain;


namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    // Delete List

    [RelayCommand]
    private async Task DeleteList(TodoList list)
    {
        await _listRepository.DeleteAsync(list.Id);
        await LoadListsAsync(); 
    }
}