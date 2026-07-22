using CommunityToolkit.Mvvm.Input;
using TodoApp.Console.Domain;
using System.Threading.Tasks;

namespace TodoApp.UI.ViewModels;

public partial class MainWindowViewModel
{
    //MarkCompleteCommand

    [RelayCommand]
    private async Task ToggleDone(TodoTask task)
    {
        task.IsDone = !task.IsDone;
        await _taskRepository.UpdateAsync(task);
    }
}