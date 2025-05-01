using lab1._4;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var books = new List<Book>();

app.MapGet("/books", () =>
{
    return books;
});

app.MapGet("/books/{id}", (int id) =>
{
    return books[id];
});

app.MapPost("/books", (Book book) =>
{
    books.Add(book);
});

app.Run();
