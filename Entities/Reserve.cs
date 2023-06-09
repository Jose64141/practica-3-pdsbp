using System.ComponentModel.DataAnnotations;

namespace Practica3_PDSBP.Entities;

public class Reserve
{

    public int Id { get; set; } 
    public DateTime Date { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}