namespace ArchiNote.Models;

public class NoteViewModel
{
    // [Required]
    // [MaxLength(30)]
    public int Id { get; set; } 
    public string? Head { get; set; }
    public string? Body { get; set; }
    public List<FilesViewModel> Files { get; set; }
}