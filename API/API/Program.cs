// MoneyTrack.API/Program.cs
using API.model;
using Microsoft.EntityFrameworkCore;
using MoneyTrack.API.Data;
using MoneyTrack.API.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MoneyTrackContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MoneyTrackContext>();

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Id = Guid.NewGuid(),
            Username = "testuser",
            Email = "test@example.com",
            PasswordHash = "hashedpassword",
            CreatedAt = DateTime.UtcNow
        });

        db.SaveChanges();
    }
    if (!db.Transactions.Any())
    {
        db.Transactions.Add(new Transaction
        {
            Id = Guid.NewGuid(),
            UserId = Guid.NewGuid(),
            Amount = 50.00m,
            Type = "Expense",
            Category = "Food",
            Description = "Groceries",
            Date = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        });
    }
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
