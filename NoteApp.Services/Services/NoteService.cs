using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;
using NoteApp.Services.Interfaces;
using NoteApp.Services.Models;

namespace NoteApp.Services.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public async Task<NoteDTO> GetNoteAsync(int id)
    {
        var note = await _noteRepository.GetAsync(id); 
        return new NoteDTO
        {                                                            
            Id = note.Id,                                            
            Head = note.Head,                                        
            Body = note.Body,                                        
            Files = note.Files.Select(file => new FileDTO
            {
                Id = file.Id,
                FileDir = file.FileDir,                              
                FileName = file.FileName                             
            }).ToList()                                              
        };
    }

    public async Task AddNoteAsync(NoteDTO note)
    {
        var files = note.Files.Select(file => new NoteFile()
        {
            FileDir = file.FileDir,
            FileName = file.FileName
        }).ToList();
        var noteNew = new Note(id: 0, note.Head, note.Body, files);
        await _noteRepository.AddAsync(noteNew);                     
    }
}