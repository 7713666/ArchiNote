using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;


namespace ArchiNote.Controllers;

[ApiController]
[Route("api/[controller]")]
        
        
public class ArchiNoteController : ControllerBase
{
    NoteContext db;
    public ArchiNoteController(NoteContext context)
    {
        db  = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Note>>> Get()
    {
        if (db.Notes != null) return (await db.Notes.ToListAsync())!;
        throw new InvalidOperationException();
    }
    
    [HttpGet("{id}")]
    public ObjectResult Get(int id)
    {
        object? note = null;
        if (note == null)
            return new ObjectResult(NotFound());
        return new ObjectResult(note);

    }
    [HttpPost]
    public async Task<ActionResult<Note>> Post(Note? work)
    {
        if (work == null)
        {
            return BadRequest();
        }
 
        db.Notes?.Add(work);
        await db.SaveChangesAsync();
        return Ok(work);
    }
    // PUT api/users/
    [HttpPut]
    public async Task<ActionResult<Note>> Put(Note? note)
    {
        if (note == null)
        {
            return BadRequest();
        }
        if (db.Notes != null && !db.Notes.Any(x => x != null && x.Id ==note.Id))
        {
            return NotFound();
        }
 
        db.Update(note);
        await db.SaveChangesAsync();
        return Ok(note);
    }
 
    // DELETE api/users/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Note>> Delete(int id)
    {
        Note? note = db.Notes?.Find(id);
        if (note == null)
        {
            return NotFound();
        }
        db.Notes?.Remove(note);
        await db.SaveChangesAsync();
        return Ok(note);
    }
}

