using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Core;


namespace NoteApp.Infrastructure.Data
{
    public class NoteRepository : INoteRepository
    {
        NoteContext db;

        public NoteRepository(NoteContext context)
        {
            db = context;
            if (!db.Notes.Any() || !db.Files.Any())
            {
                var newNote = new Note { Head = "Дело №", Body = "Газета такая" };
                db.Notes.Add(newNote);
                
                db.Files.Add(new NoteFile { FileName = "multfilm_lyagushka_32117.jpg", FileDir = "/home/bakay/Pictures/", Note = newNote});
                
                db.SaveChanges();
            }
        }
        
        public async Task<Note> GetAsync(int id)
        {
            var result = await db.Notes
                .Include(x => x.Files)
                .FirstOrDefaultAsync(x=> x.Id == id);
            return result;
        }
        
        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();
        }

        // GET api/users/5
 

        // POST api/users
        public async Task<List<Note>> AddAsync(Note note)
        {
            db.Notes?.Add(note);
            await db.SaveChangesAsync();
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();
        }
    
        // PUT api/users/
        public async Task<List<Note>> UpdateAsync(Note note)
        {
            db.Notes?.Update(note);
            await db.SaveChangesAsync();
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();
        }
        
        // DELETE api/users/5
        public async Task<List<Note>> DeleteAsync(Note note)
        {   
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();;
        }
    }
}   