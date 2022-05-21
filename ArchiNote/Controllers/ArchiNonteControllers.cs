using ArchiNote.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;
using NoteApp.Services.Interfaces;
using NoteApp.Services.Models;

namespace ArchiNote.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ArchiNoteController : ApiController
{
    private readonly INoteRepository _noteRepository;
    private readonly INoteService _noteService;

    public ArchiNoteController(NoteContext noteContext, INoteRepository noteRepository, INoteService noteService) : base(noteContext)
    {
        _noteRepository = noteRepository;
        _noteService = noteService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> Get()
    {
        var notes = await _noteRepository.GetAsync();
        var result = notes.Select(note => new NoteViewModel()
        {
            Id = note.Id,
            Head = note.Head,
            Body = note.Body,
            Files = note.Files.Select(file => new FilesViewModel()
            {
                Id = file.Id,
                FileDir = file.FileDir,
                FileName = file.FileName
            }).ToList()
        });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        return Ok(await _noteService.GetNoteAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<Note>> PostAsync(NoteDTO? note)
    {
        if (note == null)
        {
            return BadRequest();
        }

        await _noteService.AddNoteAsync(note);
        return Ok(note);
    }

    // PUT api/users/
    [HttpPut]
    public async Task<ActionResult<Note>> UpdateAsync(NoteDTO? note)
    {
        if (note == null)
        {
            return BadRequest();
        }

        var files = note.Files.Select(file => new NoteFile()
        {
            Id = file.Id,
            FileDir = file.FileDir,
            FileName = file.FileName
        }).ToList();
        var noteNew = new Note(note.Id, note.Head, note.Body, files);
        await _noteRepository.UpdateAsync(noteNew);
        return Ok(note);
    }

    // DELETE api/users/5
    [HttpDelete]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var result = await Db.Notes
            .Include(x=>x.Files)
            .FirstOrDefaultAsync(n => n.Id == id);
        if (result != null)
        {
            Db.Remove(result);
            await Db.SaveChangesAsync();
        }

        return Ok();
    }
}

