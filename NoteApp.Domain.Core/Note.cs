
namespace NoteApp.Domain.Core;

public class Note
{
    public Note(int id, string? head, string? body)
    {
        Id = id;
        Head = head;
        Body = body;
    }

    public Note()
    {
        
    }

    public int Id { get; set; }
    public string? Head { get; set; }
    public string? Body { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
}