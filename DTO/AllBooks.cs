using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.DTO;

public class BookDto
{
    public string name { get; set; }
    public string description { get; set; }
    public List<User> reservedBy { get; set; } = new List<User>();
}