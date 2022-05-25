using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;
using NoteApp.Infrastructure.Data.Interfaces;
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

    public async Task<NoteDto> GetNoteAsync(int id)
    {
        var note = await _noteRepository.GetAsync(id);
        return new NoteDto
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

    public async Task<List<NoteDto>> GetList()
    {
        var notes = await _noteRepository.GetListAsync();
        var result = notes.Select(note => new NoteDto()
        {
            Id = note.Id,
            Head = note.Head,
            Body = note.Body,
            Files = note.Files.Select(file => new FileDTO()
            {
                Id = file.Id,
                FileDir = file.FileDir,
                FileName = file.FileName
            }).ToList()
        }).ToList();
        return result;
    }
    public async Task AddNoteAsync(NoteDto note)
    {
        var files = note.Files.Select(file => new NoteFile()
        {
            FileDir = file.FileDir,
            FileName = file.FileName
        }).ToList();
        var noteNew = new Note(id: 0, note.Head, note.Body, files);
        await _noteRepository.AddAsync(noteNew);
    }

    public async Task UpdateNoteAsync(NoteDto note)
    {
        var files = note.Files.Select(file => new NoteFile()
        {
            Id = file.Id,
            FileDir = file.FileDir,
            FileName = file.FileName
        }).ToList();
        var noteNew = new Note(note.Id, note.Head, note.Body, files);
        await _noteRepository.UpdateAsync(noteNew);
    }

    public async Task<NoteDto> DeleteNoteAsync(int id)
    {
        var note = await _noteRepository.DeleteAsync(id);
        return new NoteDto
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
   

}