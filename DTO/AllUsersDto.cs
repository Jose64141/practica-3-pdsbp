using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.DTO;

public class UserDto
{
    public string name { get; set; }
    public string faculty { get; set; }
    public DateTime? date_last_reserve { get; set; }
    public int cantLastReserve { get; set; }
    public List<Book> reserves { get; set; } = new List<Book>();
}