namespace NoteApp.Services.Models;

public class NoteDto
{
    public int Id { get; set; }
    public string? Head { get; set; }
    public string? Body { get; set; }
    public List<FileDTO> Files { get; set; }
}