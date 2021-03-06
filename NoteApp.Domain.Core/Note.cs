namespace NoteApp.Domain.Core;

public class Note : IDisposable
{
    public Note(int id, string? head, string? body,  ICollection<NoteFile>? files)
    {
        Id = id;
        Head = head;
        Body = body;
        Files = files;
    }

    public Note(int id, string noteHead, string noteBody)
    {
        Id = id;
        Head = noteHead;
        Body = noteBody;
    }
    
    public Note(ICollection<NoteFile>? files)
    {
        Files = files;
    }

    public Note()
    {
    }
    


    public int Id { get; set; }
    public string? Head { get; set; }
    public string? Body { get; set; }
    public DateTime DateTime { get; set; } = DateTime.Now;
    public ICollection<NoteFile>? Files { get; set; }

    public void Dispose()
    {
    }


}

public class NoteFile
{
    public NoteFile(int id, string? fileName, string? fileDir, Note? note)
    {
        Id = id;
        FileName = fileName;
        FileDir = fileDir;
        Note = note;
    }

    public NoteFile()
    {
    }

    public int Id { get; set; }
    public string? FileName { get; set; }
    public string? FileDir { get; set; }
    public int NoteId { get; set; }
    public Note? Note { get; set; }
}