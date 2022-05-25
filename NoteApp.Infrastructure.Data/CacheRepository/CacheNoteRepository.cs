using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data.Interfaces;

namespace NoteApp.Infrastructure.Data;

public class CacheNoteRepository : INoteRepository
{
    public Task<IEnumerable<Note>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Note> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Note>> AddAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task<List<Note>> UpdateAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task<Note> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Note>> DeleteAsync(Note note)
    {
        throw new NotImplementedException();
    }
}