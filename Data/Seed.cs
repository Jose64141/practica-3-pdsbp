using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Practica3_PDSBP.Entities;

namespace Practica3_PDSBP.Data;

public class Seed
{
    public static void SeedData(DataContext context)
    {
        if (context == null) throw new ArgumentNullException(nameof(context));
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        SeedUsers(context, options);
        SeedBooks(context, options);
        SeedReserves(context, options);
        context.SaveChanges();

    }

    static void SeedUsers(DataContext context, JsonSerializerOptions options)
    {
        if (context.Users.Any()) return;
        var userData = File.ReadAllText("Data/Seed/Users.json");
        var usersList = JsonSerializer.Deserialize<List<User>>(userData, options);
        context.AddRange(usersList);
        context.SaveChanges();
    }
    
    static void SeedBooks(DataContext context, JsonSerializerOptions options)
    {
        if (context.Books.Any()) return;
        var bookData = File.ReadAllText("Data/Seed/Books.json");
        var booksList = JsonSerializer.Deserialize<List<Book>>(bookData, options);
        context.AddRange(booksList);
        context.SaveChanges();
    }
    
    static void SeedReserves(DataContext context, JsonSerializerOptions options)
    {
        if (context.Reserves.Any()) return;
        var reserveData = File.ReadAllText("Data/Seed/Reserves.json");
        var reservesList = JsonSerializer.Deserialize<List<Reserve>>(reserveData, options);
        context.AddRange(reservesList);
        context.SaveChanges();
    }
}