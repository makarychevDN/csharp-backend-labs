using lab1._3;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var tasks = new List<TaskItem>();

app.MapPost("/tasks", (TaskItem task) =>
{
    if (task.Title == null)
        return Results.BadRequest("название не может быть пустым");

    tasks.Add(task);
    return Results.Created($"/tasks/{task.Id}", task);
});

app.MapPost("/tasksrange", (TaskItem[] newTasks) =>
{
    tasks.AddRange(newTasks);
    return Results.Created($"/tasksrange/", tasks);
});

app.MapGet("/tasks/{id}", (int id) =>
{
    var targetTask = tasks.FirstOrDefault(task => task.Id == id);

    if (targetTask == null)
        return Results.NotFound();

    return Results.Ok(targetTask);
});

app.MapGet("/tasks", () => tasks);

app.Run();
