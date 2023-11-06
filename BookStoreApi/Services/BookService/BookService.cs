using AutoMapper;
using BookStoreApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly SampleDbContext _context;
        public BookService(SampleDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null) return null;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> GetBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book is null) return null;

            return  book;
        }

        public async Task<List<Book>> GetBooks()
        {
            var result =  await _context.Books.ToListAsync();
            return result;
        }

        public async Task<ActionResult<Book>> UpdateBook(int id, Book request)
        {
            var book = await _context.Books.FindAsync(id);
            if (book is null) return null;

            book.Title = request.Title;
            book.Description = request.Description;
            book.Author = request.Author;
            book.price = request.price;

            await _context.SaveChangesAsync();
            return book;
        }
    }
}
