using Avalonia.Controls;
using Avalonia.Interactivity;
using TodoApp.Console.Domain;
using TodoApp.UI.ViewModels;

namespace TodoApp.UI.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void OnToggleDone(object sender, RoutedEventArgs e)
    {
        if (sender is CheckBox { Tag: TodoTask task } && DataContext is MainWindowViewModel vm)
        {
            await vm.UpdateTaskCommand.ExecuteAsync(task);
        }
    }
}