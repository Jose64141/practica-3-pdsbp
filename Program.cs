using Microsoft.EntityFrameworkCore;
using Practica3_PDSBP.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:3000");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DataContext>();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
try
{
    context.Database.Migrate();
    Seed.SeedData(context);
}
catch (Exception ex)
{
    logger.LogError(ex, " A problem ocurred during seeding ");
}

app.Run();
