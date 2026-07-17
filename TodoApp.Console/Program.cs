using System;
using TodoApp.Console.Domain;
using TodoApp.Console.Data;

var context = new TodoDbContext();
var repository = new TaskRepository(context);


//Create task:
var newTask = new TodoTask()
{
    Title =  "New Task testing",
    IsDone = false,
    CreatedAt =  DateTime.UtcNow,
};

await repository.AddAsync(newTask);
Console.WriteLine($"Added task with Id: {newTask.Id}");


//Read task:
var allTasks = await repository.GetAllAsync();
Console.WriteLine($"Total tasks in database: {allTasks.Count}");
foreach (var task in allTasks)
{
    Console.WriteLine($"- [{task.Id}] {task.Title} (Done: {task.IsDone})");
}