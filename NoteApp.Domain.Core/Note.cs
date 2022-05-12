namespace NoteApp.Domain.Core;

public class Note
{
    public Note(int id, string? head, string? body, ICollection<File> files)
    {
        Id = id;
        Head = head;
        Body = body;
        Files = files;
    }

    public Note(ICollection<File> files)
    {
        Files = files;
    }

    public Note()
    {
    }
    public Note(int id, string noteHead, string noteBody)
    {
    }

    public int Id { get; set; }
    public string? Head { get; set; }
    public string? Body { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public ICollection<File> Files { get; set; }
}

public class File
{
    public File(int id, string? fileName, string? fileDir, Note note)
    {
        Id = id;
        FileName = fileName;
        FileDir = fileDir;
        Note = note;
    }

    public File()
    {
    }


    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? FileDir { get; set; }
    public Note Note { get; set; }
}