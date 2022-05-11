using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteApp.Domain.Core;
using File = NoteApp.Domain.Core.File;

namespace Configuration;

public class NoteConfiguration : IEntityTypeConfiguration<Note> 
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder.ToTable("notes");

        builder.Property(c => c.Id)
                .HasColumnName("id")
                .IsRequired();
        
        builder.Property(c => c.Head)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(30);
        
        builder.Property(c => c.Body)
                .HasColumnName("essence")
                .IsRequired()
                .HasMaxLength(30);
        
        builder.Property(c => c.DateTime)
                .HasColumnName("datetime")
                .IsRequired()
                .HasColumnType("datetime");
        
    }
}

public class FileConfiguration : IEntityTypeConfiguration<File> 
{
        public void Configure(EntityTypeBuilder<File> builder)
        {
                builder.ToTable("files");

                builder.Property(c => c.FileName)
                        .HasColumnName("file_name")
                        .IsRequired()
                        .HasMaxLength(10);
                
                builder.Property("file_dir")
                        .HasColumnName("file_name")
                        .IsRequired()
                        .HasColumnType(varchar(MAX));
                        
        }
}