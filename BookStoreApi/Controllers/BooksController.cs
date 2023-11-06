using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper) 
        { 
            _bookService = bookService;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return await _bookService.GetBooks();
        }

        [HttpGet("bookCover")]
        public async Task<ActionResult<List<Book>>> GetBooksCover()
        {
            var result =  await _bookService.GetBooks();
            return Ok(result.Select(book => _mapper.Map<BookCoverDto>(book)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            var result =  await _bookService.GetBook(id);
            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book) 
        {
            var result = await _bookService.AddBook(book);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, Book book)
        {
            var result = await _bookService.UpdateBook(id, book);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);
            if (result is null)
                return NotFound();
            return Ok(result);
        }
    }
}
