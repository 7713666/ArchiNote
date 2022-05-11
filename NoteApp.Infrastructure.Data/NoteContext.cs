using Configuration;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;

namespace NoteApp.Infrastructure.Data;

public  class NoteContext : DbContext
{
    protected NoteContext(DbSet<Note>? notes)
    {
        Notes = notes;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
    }

    public NoteContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Note>? Notes { get; set; }
    
 
}