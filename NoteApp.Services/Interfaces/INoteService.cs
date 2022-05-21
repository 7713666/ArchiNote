using NoteApp.Domain.Core;
using NoteApp.Services.Models;

namespace NoteApp.Services.Interfaces;

public interface INoteService
{
    Task<NoteDto> GetNoteAsync(int id);
    Task AddNoteAsync(NoteDto note);
    Task UpdateNoteAsync(NoteDto note);
    Task<NoteDto> DeleteNoteAsync(int id);
}