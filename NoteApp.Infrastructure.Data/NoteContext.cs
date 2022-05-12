using Configuration;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;
using File = NoteApp.Domain.Core.File;

namespace NoteApp.Infrastructure.Data;

public  class NoteContext : DbContext
{
    protected NoteContext(DbSet<Note>? notes, DbSet<File>? files)
    {
        Notes = notes;
        Files = files;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
                modelBuilder.ApplyConfiguration(new NoteConfiguration());
                modelBuilder.ApplyConfiguration(new FileConfiguration());
    }
    public NoteContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Note>? Notes { get; set; }
    public DbSet<File>? Files { get; set; }
}