using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.Domain.Core;

[Table("Note")]
public class Note
{
    public Note(string head, string body)
    {
        Head = head;
        Body = body;
    }

    public int Id { get; set; }

    public string Head { get; set; }

    public string Body { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;  
    
}