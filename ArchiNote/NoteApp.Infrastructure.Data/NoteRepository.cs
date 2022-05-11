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
        
        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await db.Notes.ToListAsync();
        }

        // GET api/users/5
       public async Task<Note> GetAsync(int id)
        {
            Note? note = await db.Notes.FirstOrDefaultAsync(x => x.Id == id);
            return note;
        }

        // POST api/users
        public async Task<Note?> AddAsync(Note note)
        {
            db.Notes?.Add(note);
            await db.SaveChangesAsync();
            return note;
        }
        
        // PUT api/users/
        public async Task<Note> UpdateAsync(Note note)
        {
            db.Update(note);
            await db.SaveChangesAsync();
            return note;
        }
        
        // DELETE api/users/5
        public async Task<Note?> DeleteAsync(int id)
        {
            Note? note = db.Notes.FirstOrDefault(x => x.Id == id);
            if (note == null)
                return null;
            db.Notes.Remove(note);
            await db.SaveChangesAsync();
            return note;                           

        }
    }
}   