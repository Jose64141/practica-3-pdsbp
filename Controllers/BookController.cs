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
        List<BookResponseDto> result = new List<BookResponseDto>();
        List<Book> books = _context.Books.ToList();
        foreach (var book in books)
        {
            BookResponseDto bookResponseInfo = new BookResponseDto();
            bookResponseInfo.Name = book.Name;
            bookResponseInfo.Description = book.Description;
            bookResponseInfo.ReservedBy = _context.Reserves
                .Where(reserve => reserve.BookId == book.Id)
                .Select(reserve => new UserDto
                {
                    Id = reserve.User.Id,          
                    Name = reserve.User.Name,      
                    Faculty = reserve.User.Faculty
                })
                .Distinct()
                .ToList();

            result.Add(bookResponseInfo);
        }
        return Ok(result);
    }
}