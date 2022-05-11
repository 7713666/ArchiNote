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

public class File
{
    public File(int id, string filename, string filedir)
    {
        Id = id;
        FileName = filename;
        FileDir = filedir;
    }

    public File()
    {
    }
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FileDir { get; set; }
}