using Microsoft.EntityFrameworkCore;
using NoteApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Design;
using NoteApp.Infrastructure.Data.Interfaces;
using NoteApp.Services.Interfaces;
using NoteApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = "server=localhost;user=sa;password=Moiparol7713!;database=Notes";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));
builder.Services.AddDbContext<NoteContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors());

// builder.Services.AddSingleton()
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();
// builder.Services.AddScoped<INoteRepository, CacheNoteRepository>();
// builder.Services.AddScoped<NoteRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();{}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();