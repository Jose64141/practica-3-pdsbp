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
        List<UserDto> result = new List<UserDto>();
        List<User> users = _context.Users.ToList();
        foreach (var user in users)
        {
            UserDto userData = new UserDto();
            userData.name = user.Name;
            userData.faculty = user.Faculty;
            var lastReserveDate = _context.Reserves.Where(reserve => reserve.UserId == user.Id)
                .OrderByDescending(reserve => reserve.Date).ToList();
             if(lastReserveDate.Count >0) userData.date_last_reserve =lastReserveDate[0].Date;
             int count = _context.Reserves.Where(reserve => reserve.UserId == user.Id && reserve.Date > DateTime.Now.AddMonths(-1)).Count();
             userData.cantLastReserve = count;
             var reserves =   _context.Reserves.Where(reserve => reserve.UserId == user.Id).ToList();
             foreach (var reserve in reserves)
             {
                 userData.reserves.Append(reserve.Book);
             }

             result.Append(userData);
        }
        return Ok(result);
    }
}