using lab1._4;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var books = new List<Book>();

app.MapGet("/books", async () =>
{
    await Task.Delay(500);
    return Results.Ok(books);
});

app.MapGet("/books/{id}", async (int id) =>
{
    await Task.Delay(300);

    var requiredBook = books.FirstOrDefault(books => books.Id == id);

    if (requiredBook == null)
        return Results.NotFound($"the book with id {id} is not found");

    if (requiredBook.Title == "")
        return Results.BadRequest($"the book with id {id} doesn't have a Title");

    return Results.Ok(requiredBook);
});

app.MapPost("/books", async (Book book) =>
{
    await Task.Delay(300);

    if (book == null)
        return Results.BadRequest("can't add null as a book");

    books.Add(book);
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPost("/booksrange", async(Book[] newBooks) =>
{
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    await Task.Delay(5000);

    stopwatch.Stop();
    Console.WriteLine(stopwatch.Elapsed.ToString());

    if (newBooks == null)
        return Results.BadRequest("can't add null as a book");

    books.AddRange(newBooks);
    return Results.Created($"/booksrange", books);
});

app.MapPut("/books/{id}", async (int id, Book updatedBook) =>
{
    await Task.Delay(1);

    var requiredBook = books.FirstOrDefault(books => books.Id == id);

    if(requiredBook == null)
        return Results.NotFound();

    books.Remove(requiredBook);
    updatedBook = new Book(id, updatedBook.Title, updatedBook.Author);
    books.Add(updatedBook);

    return Results.Ok(updatedBook);
});

app.MapDelete("/books/{id}", async (int id) =>
{
    await Task.Delay(1);

    var requiredBook = books.FirstOrDefault(book => book.Id == id);

    if(requiredBook == null)
        return Results.NotFound();

    books.Remove(requiredBook);
    return Results.Ok(requiredBook);
});

app.Run();
