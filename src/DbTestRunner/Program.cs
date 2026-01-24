using Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

var connection = new SqliteConnection("DataSource=:memory:");
connection.Open();

var options = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite(connection)
    .Options;

using var context = new AppDbContext(options);
context.Database.EnsureCreated();

// Test insert
context.Users.Add(new Domain.Entities.User
{
    Name = "Test User",
    Email = "test@example.com"
});

context.SaveChanges();

Console.WriteLine($"Users in DB: {context.Users.Count()}");