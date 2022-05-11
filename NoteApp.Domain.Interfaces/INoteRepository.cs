using NoteApp.Domain.Core;

namespace NoteApp.Domain.Interfaces
{
    public interface INoteRepository: IDisposable
    {
        IEnumerable<Note> GetNotes();
        Note Get(int id);
        void Post(Note note);
        void Update(Note item);
        void Delete(int id);
        void Save();
    }
}