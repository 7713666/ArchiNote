using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NoteApp.Domain.Core;


namespace NoteApp.Infrastructure.Data
{
    public class NoteRepository 
    {
        NoteContext db;

        public NoteRepository(NoteContext context)
        {
            db = context;
            if (!db.Notes.Any() || !db.Files.Any())
            {   
                db.Notes.Add(new Note 
                    { Head = "Дело №", Body = "Газета такая"});
                
                db.Files.Add(new NoteFile 
                    { FileName = "multfilm_lyagushka_32117.jpg", FileDir = "/home/bakay/Pictures/"});
                
                db.SaveChanges();
            }
        }
        public async Task<IEnumerable<Note>> GetAsync()
        {
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();
        }

        // GET api/users/5
       public async Task<List<Note>> GetAsync(int id)
        {
            var result = await db.Notes
                .Include(x => x.Id == id)
                .ToListAsync();
            return result;
        }

        // POST api/users
        public async Task<Note?> AddAsync(Note note)
        {
            await db.Notes.AddAsync(note);
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
        public async Task<List<Note>> DeleteAsync(int id)
        {
            var result = await db.Notes
                .Include(x => x.Id == id)
                .ToListAsync();
                db.Remove(result);
                await db.SaveChangesAsync();
                return result;
        }
    }
}   