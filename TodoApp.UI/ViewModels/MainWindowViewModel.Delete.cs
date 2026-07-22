using CommunityToolkit.Mvvm.Input;
using System.Threading.Tasks;
using TodoApp.Console.Domain;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    //DeleteTaskCommand

    [RelayCommand]
    private async Task DeleteTask(TodoTask task)
    {
        await _taskRepository.DeleteAsync(task.Id); 
        await LoadTasksAsync();
    }
}