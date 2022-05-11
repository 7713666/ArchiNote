using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteApp.Domain.Core;

namespace Configuration;

public class NoteConfiguration : IEntityTypeConfiguration<Note> 
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.Property(c => c.Id).HasColumnName("id").IsRequired();
        builder.Property(c => c.Head).HasColumnName("title").IsRequired().HasMaxLength(30);
        builder.Property(c => c.Body).HasColumnName("essence").IsRequired().HasMaxLength(30);
        builder.Property(c => c.DateTime).HasColumnName("datetime").IsRequired().HasColumnType("datetime");
        builder.ToTable("notes");
    }
}   