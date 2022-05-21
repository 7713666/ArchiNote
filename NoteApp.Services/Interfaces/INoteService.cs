using NoteApp.Domain.Core;
using NoteApp.Services.Models;

namespace NoteApp.Services.Interfaces;

public interface INoteService
{
    Task<NoteDTO> GetNoteAsync(int id);
    Task AddNoteAsync(NoteDTO note);
}