using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;

namespace NoteApp.Infrastructure.Data;

public  class NoteContext : DbContext
{
    protected NoteContext(DbSet<Note>? notes)
    {
        Notes = notes;
    }

    public NoteContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Note>? Notes { get; set; }
 
}