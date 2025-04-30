var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var usersDictionary = new Dictionary<int, User>() 
{
    { 0, new User("������") },
    { 1, new User("����") },
    { 2, new User("������") },
    { 3, new User("����") },
};

app.MapGet("/hello", () => "������, API!");
app.MapGet("/hello/{name}", (string name) => $"������, {name}!");
app.MapGet("/movie", () =>
{
    var movie = new { Title = "Inception", Year = 2010 };
    return movie;
});
app.MapGet("/user/{id}", (int id) => {
    if (!usersDictionary.ContainsKey(id))
        return null;

    return usersDictionary[id];
});

app.MapGet("/userpro/{id}", (int id) =>
{
    if (!usersDictionary.ContainsKey(id))
        return Results.NotFound();

    return Results.Json(usersDictionary[id]);
});

app.Run();

public class User
{
    public string Name { get; set; }

    public User(string name) 
    {
        Name = name; 
    }
}