using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;


namespace ArchiNote.Controllers;

public class NoteViewModel
{
    [Required]
    [MaxLength(30)]
    public int Id { get; set; } 
    public string Head { get; set; }
    public string Body { get; set; }
    public List<FilesViewModel> Files { get; set; }
}

    public class FilesViewModel
    {
        public string? FileName { get; set; }
        public string? FileDir { get; set; }
        
    }

[ApiController]
[Route("api/[controller]")]

public class ArchiNoteController : ControllerBase
{
    NoteContext db;
    private readonly NoteRepository noteRepository;

    public ArchiNoteController(NoteContext context)
    {
        db  = context;
        noteRepository = new NoteRepository(context);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> Get()
    {
        var notes = await noteRepository.GetAsync();
        var result = notes.Select(note => new NoteViewModel()
        {
            Id = note.Id,
            Head = note.Head,
            Body = note.Body,
            Files = note.Files.Select(file => new FilesViewModel()
            {
                FileDir = file.FileDir,
                FileName = file.FileName
            }).ToList()
        });
        return Ok(result);
    }
    
    
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var note = await noteRepository.GetAsync(id);
        if (note == null)
            return NotFound();
        return Ok(note);

    }
    [HttpPost]
    public async Task<ActionResult<Note>> PostAsync(NoteViewModel? note)
    {
        if (note == null)
        {
            return BadRequest();
        }

        var noteNew = new Note(id:0, note.Head, note.Body);
        await noteRepository.AddAsync(noteNew); 
        return Ok(note);
    }
    
    // PUT api/users/
    [HttpPut]
    public async Task<ActionResult<Note>> PutAsync(NoteViewModel? note)
    {
        if (note == null)
        {
            return BadRequest();
        }
        
        if (!db.Notes.Any(x => x.Id == note.Id))
        {
            return NotFound();
        }
        var noteNew = new Note(0, note.Head, note.Body);
        await noteRepository.UpdateAsync(noteNew);
        return Ok(note);
    }
 
    // DELETE api/users/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Note>> Delete(int id)
    {
        var note = await noteRepository.DeleteAsync(id);
        if (note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }
}

