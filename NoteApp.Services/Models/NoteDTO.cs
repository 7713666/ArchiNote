namespace NoteApp.Services.Models;

public class NoteDto
{
    public int Id { get; set; }
    public string? Head { get; set; }
    public string? Body { get; set; }
    public List<FileDTO> Files { get; set; }

    public NoteDto(int id, string? head, string? body, List<FileDTO> files)
    {
        Id = id;
        Head = head;
        Body = body;
        Files = files;
    }

    public NoteDto()
    {
        throw new NotImplementedException();
    }
}