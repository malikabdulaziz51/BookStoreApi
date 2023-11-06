

using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>>? GetBooks();

        Task<Book>? GetBook(int id);

        Task<ActionResult<Book>>? AddBook(Book book);

        Task<ActionResult<Book>>? UpdateBook(int id, Book book);

        Task<ActionResult<Book>>? DeleteBook(int id);
    }
}
