using NoteApp.Domain.Core;

namespace NoteApp.Infrastructure.Data.Interfaces;

public interface INoteRepository
{
    Task<IEnumerable<Note>> GetAsync();
    Task<Note> GetAsync(int id);
    Task<List<Note>> AddAsync(Note note);
    Task<List<Note>> UpdateAsync(Note note);
    Task<Note?> DeleteAsync(int id);
}