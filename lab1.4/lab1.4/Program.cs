using lab1._4;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var books = new List<Book>();

app.MapGet("/books", () =>
{
    return Results.Ok(books);
});

app.MapGet("/books/{id}", (int id) =>
{
    if (id >= books.Count)
        return Results.BadRequest($"the book with id {id} is non found");

    return Results.Ok(books[id]);
});

app.MapPost("/books", (Book book) =>
{
    if (book == null)
        return Results.BadRequest("can't add null as a book");

    books.Add(book);
    return Results.Created($"/books/{books.IndexOf(book)}", book);
});

app.Run();
