using System.ComponentModel.DataAnnotations;

namespace ArchiNote.Models;

public class FilesViewModel
{
    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? FileDir { get; set; }
}