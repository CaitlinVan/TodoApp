using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace TodoApp.Console.Domain;

public partial class TodoTask : ObservableObject
{
    public int Id { get; set; }
    public int? ListId { get; set; }
    public string Title { get; set; } =  string.Empty;
    public string? Description { get; set; }
    
    [ObservableProperty]
    private bool _isDone;
    
    public int? Priority { get; set; }
    public bool IsPinned { get; set; }
    public string? Color { get; set; }
    public DateOnly? due_date { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public TodoList? List { get; set; }
    public List<Tag> Tags { get; set; }
    
}