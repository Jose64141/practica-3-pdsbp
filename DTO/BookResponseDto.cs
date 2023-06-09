using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.DTO;

public class BookResponseDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<UserDto> ReservedBy { get; set; } = new List<UserDto>();
}