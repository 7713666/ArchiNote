using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoteApp.Domain.Core;

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
public class FileConfiguration : IEntityTypeConfiguration<NoteFile> 
{
        public void Configure(EntityTypeBuilder<NoteFile> builder)
        {
                builder.ToTable("files");
                
                builder.Property(c => c.Id)
                        .HasColumnName("id")
                        .IsRequired();

                builder.Property(c => c.FileName)
                        .HasColumnName("file_name")
                        .IsRequired()
                        .HasMaxLength(30);
                
                builder.Property(c=> c.FileDir)
                        .HasColumnName("file_dir")
                        .IsRequired()
                        .HasMaxLength(65535);

                builder.HasOne(e => e.Note)
                        .WithMany(c => c.Files)
                        .HasForeignKey(c => c.NoteId)
                        .OnDelete(DeleteBehavior.Restrict);

        }
        
}