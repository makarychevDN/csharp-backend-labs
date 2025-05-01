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
    var requiredBook = books.FirstOrDefault(books => books.Id == id);

    if (requiredBook == null)
        return Results.BadRequest($"the book with id {id} is non found");

    return Results.Ok(requiredBook);
});

app.MapPost("/books", (Book book) =>
{
    if (book == null)
        return Results.BadRequest("can't add null as a book");

    books.Add(book);
    return Results.Created($"/books/{book.Id}", book);
});

app.MapPost("/booksrange", (Book[] newBooks) =>
{
    if (newBooks == null)
        return Results.BadRequest("can't add null as a book");

    books.AddRange(newBooks);
    return Results.Created($"/booksrange", books);
});

app.Run();
