using Microsoft.AspNetCore.Mvc;
using Practica3_PDSBP.Data;
using Practica3_PDSBP.DTO;
using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    
    private readonly DataContext _context;

    public BookController(DataContext context)
    {
        _context = context;
    }
    [HttpGet("/all-books")]
    public IActionResult AllBooks()
    {
        List<BookDto> result = new List<BookDto>();
        List<Book> books = _context.Books.ToList();
        foreach (var book in books)
        {
            BookDto bookInfo = new BookDto();
            bookInfo.name = book.Name;
            bookInfo.description = book.Description;
            var reserves =   _context.Reserves.Where(reserve => reserve.BookId == book.Id).ToList();
            foreach (var reserve in reserves)
            {
                bookInfo.reservedBy.Append(reserve.User);
            }

            result.Append(bookInfo);
        }
        return Ok(result);
    }
}