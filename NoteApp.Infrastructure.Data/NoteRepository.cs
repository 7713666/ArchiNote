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
        public async Task<List<Note>> AddAsync(Note note)
        {
            return await db.Notes
                .Include(x => x.Files)
                .ToListAsync();
        }

        // PUT api/users/
        public async Task<List<Note>> UpdateAsync(Note note)
        {
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