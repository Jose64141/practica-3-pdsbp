using Microsoft.AspNetCore.Mvc;
using Practica3_PDSBP.Data;
using Practica3_PDSBP.DTO;
using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("/all-users")]
    public IActionResult AllUsers()
    {
        List<UserResponseDto> result = new List<UserResponseDto>();
        List<User> users = _context.Users.ToList();
        foreach (var user in users)
        {
            UserResponseDto userResponseData = new UserResponseDto();
            userResponseData.Name = user.Name;
            userResponseData.Faculty = user.Faculty;
            var lastReserveDate = _context.Reserves.Where(reserve => reserve.UserId == user.Id)
                .OrderByDescending(reserve => reserve.Date).ToList();
             if(lastReserveDate.Count >0) userResponseData.lastReserveDate =lastReserveDate[0].Date;
             int count = _context.Reserves.Where(reserve => reserve.UserId == user.Id && reserve.Date > DateTime.Now.AddMonths(-1)).Count();
             userResponseData.LastMonthReserveQty = count;
             userResponseData.Reserves =   _context.Reserves
                 .Where(reserve => reserve.UserId == user.Id)
                 
                 .Select(reserve => new BookDto
                 {
                     Id = reserve.Book.Id,
                     Name = reserve.Book.Name,
                     Code = reserve.Book.Code,
                     Description = reserve.Book.Description
                 })
                 .Distinct()
                 .ToList();

             result.Add(userResponseData);
        }
        return Ok(result);
    }
}