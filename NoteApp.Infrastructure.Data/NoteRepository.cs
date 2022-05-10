using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;


namespace NoteApp.Infrastructure.Data
{
    public class NoteRepository 
    {
        NoteContext db;

        public NoteRepository(NoteContext context)
        {
            db = context;
            if (!db.Notes.Any())
            {
                db.Notes.Add(new Note{ Head = "Дело №", Body = "Газета такая" });
                db.SaveChanges();
            }
        }
        
        public async Task<ActionResult<IEnumerable<Note>>> Get()
        {
            return await db.Notes.ToListAsync();
        }

        // GET api/users/5
       
        public async Task<Note> Get(int id)
        {
            Note? note = await db.Notes.FirstOrDefaultAsync(x => x.Id == id);
            return note;
        }

        // POST api/users
        public async Task<Note?> Post(Note? note)
        {
            db.Notes?.Add(note);
            await db.SaveChangesAsync();
            return note;
        }
        
        // PUT api/users/
        public async Task<Note> Put(Note note)
        {
            db.Update(note);
            await db.SaveChangesAsync();
            return note;
        }
        
        // DELETE api/users/5
        public async Task<ActionResult<Note>> Delete(int id)
        {
            Note? note = db.Notes.FirstOrDefault(x => x.Id == id);

            db.Notes.Remove(note);
            await db.SaveChangesAsync();
            return note;

        }
    }
}   