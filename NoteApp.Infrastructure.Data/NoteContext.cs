using Configuration;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;

namespace NoteApp.Infrastructure.Data;

public  class NoteContext : DbContext
{
    protected NoteContext(DbSet<Note>? notes, DbSet<NoteFile>? files)
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
    public DbSet<NoteFile>? Files { get; set; }
}