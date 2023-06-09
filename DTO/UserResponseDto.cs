using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.DTO;

public class UserResponseDto
{
    public string Name { get; set; }
    public string Faculty { get; set; }
    public DateTime? lastReserveDate { get; set; }
    public int LastMonthReserveQty { get; set; }
    public List<BookDto> Reserves { get; set; } = new List<BookDto>();
}