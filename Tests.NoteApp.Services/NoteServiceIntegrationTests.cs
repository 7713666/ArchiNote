using System.Collections;
using System.Reflection.Metadata.Ecma335;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;
using NoteApp.Infrastructure.Data.DbRepository;
using NoteApp.Infrastructure.Data.Interfaces;
using NoteApp.Services.Models;
using NoteApp.Services.Services;

namespace Tests.NoteApp.Services;

public class NoteRepositoryStub : INoteRepository
{
    public Task<IEnumerable<Note>> GetListAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Note> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Note>> AddAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task<List<Note>> UpdateAsync(Note note)
    {
        throw new NotImplementedException();
        
    }    
       

    public Task<Note> DeleteAsync(int id)
    {
        return Task.FromResult(new Note(1, "adwwd", "awdawd", new List<NoteFile>()));
    }
}


public class NoteServiceTests
{
    private NoteService _service;
    private Mock<INoteRepository> _repositoryMock;



    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<INoteRepository>();
        _service = new NoteService(_repositoryMock.Object);
    }
    
    [Test]
    public async Task DeleteNoteAsync_Should_ReturnNote_When_DeleteCalled()
    {
        _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(new Note(1, "adwwd", "awdawd", new List<NoteFile>()));
        
        var actual = await _service.DeleteNoteAsync(1);
        
        actual.Should().NotBeNull();
        
    }

    [Test]
    public async Task GetNoteAsync_Should_ReturnNote_When_GetCalled_By_Id()
    {
        _repositoryMock.Setup(x => x.GetAsync(It.IsAny<int>()))
            .ReturnsAsync(new Note(1, "adwwd", "awdawd", new List<NoteFile>()));
        
        var actual = await _service.GetNoteAsync(1);
        
        actual.Should().NotBeNull();

    }    
    
    
    [Test]
    public async Task GetNoteAsync_Should_ReturnNote_When_Get_All_List()
    {
        _repositoryMock.Setup(
            r => r.GetListAsync()
        ).ReturnsAsync(new List<Note> { new Note( 1, "1asdas", "asdasdasad", new List<NoteFile>()) });
           
            
        var actual = await _service.GetList();
        
        actual.Should().NotBeNull();
    }
    
    [Test]
    public async Task AddNoteAsync_Should_ReturnNote_When_Add_Notes()
    {
            _repositoryMock.Setup(x => x.AddAsync(It.IsAny<Note>())
                );

           await _service.AddNoteAsync(new NoteDto(1, "1asdas", "asdasdasad", new List<FileDTO>()));
        
        _repositoryMock.Verify(x=>x.AddAsync(It.Is<Note>(c=>c.Body != null && c.Head != null)), Times.Once);
    }
    
    [Test]
    public async Task UpdateNoteAsync_Should_ReturnNote_When_Update_Notes()
    {
        _repositoryMock.Setup(x => x.UpdateAsync(It.IsAny<Note>())
        );

        await _service.UpdateNoteAsync(new NoteDto(1, "1asdas", "asdasdasad", new List<FileDTO>()));
        
        _repositoryMock.Verify(x=>x.UpdateAsync(It.Is<Note>(c=>c.Body != null && c.Head != null)), Times.Once);
    }

    
    
}



[NonParallelizable]
public class NoteServiceIntegrationTests
{
    private NoteService _service;
    private NoteContext _context;

    [SetUp]
    public async Task SetupAsync()
    {
        var optionsBuilder = new DbContextOptionsBuilder<NoteContext>()
            .UseMySql("server=localhost;user=sa;password=Moiparol7713!;database=test_notes",
                new MySqlServerVersion(new Version(8, 0, 25)));
        _context = new NoteContext(optionsBuilder.Options);
        await _context.Database.EnsureCreatedAsync();

        _service = new NoteService(new NoteRepository(_context));
    }

    [TearDown]
    public async Task TearDown()
    {
        await _context.Database.EnsureDeletedAsync();
    }

    [Test]
    public async Task AddNoteAsync_Should_ReturnNote_When_AddCalled()
    {
        await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw"));
        await _context.SaveChangesAsync();
    
        var actual = await _service.DeleteNoteAsync(1);
    
        Assert.IsNotNull(actual);
    }
    
    [Test]
    public async Task UpdateNoteAsync_Should_ReturnNote_When_UpdateCalled()
    {
        await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw", null));
        await _context.SaveChangesAsync();
    
        var note = await _context.Notes.FindAsync(1);
        note.Head = "1awdwad";
        note.Body = "wadawdwad";
        note.Files = null;
    
        _context.Notes.Update(note);
        await _context.SaveChangesAsync();
    
        var actual = await _service.DeleteNoteAsync(1);
    
        actual.Id.Should().BePositive();
        actual.Head.Should().Be("1awdwad");
        actual.Body.Should().Be("wadawdwad");
        actual.Files.Should().BeEmpty();
    }
    
    [Test]
    public async Task DeleteNoteAsync_Should_ReturnNote_When_Is_No_Need_Anymore()
    {
        await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw"));
        await _context.Notes.AddAsync(new Note(2, "asdwadaw", "adsssswdw"));
        await _context.Notes.AddAsync(new Note(3, "wad777aw", "a666dwdw"));
    
        await _context.SaveChangesAsync();
    
        var actual = await _service.DeleteNoteAsync(2);
    
        actual.Id.Should().Be(2);
        actual.Head.Should().Be("asdwadaw");
        actual.Body.Should().Be("adsssswdw");
    }

    [Test]
    public async Task GetNoteAsync_Should_ReturnNote_When_I_Want()
    {
        await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw"));
        await _context.Notes.AddAsync(new Note(2, "asdwadaw", "adsssswdw"));
        await _context.Notes.AddAsync(new Note(3, "wad777aw", "a666dwdw"));
    
        await _context.SaveChangesAsync();
    
        var actual = await _context.Notes.FindAsync(3);
    
        actual.Id.Should().Be(3);
        actual.Head.Should().Be("wad777aw");
        actual.Body.Should().Be("a666dwdw");
    }

    [Test]
    public async Task GetNoteAsync_Should_ReturnNote_When_I_Want_All()
    {
        try
        {
            await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw"));
            await _context.Notes.AddAsync(new Note(2, "asdwadaw", "adsssswdw"));
            await _context.Notes.AddAsync(new Note(3, "wad777aw", "a666dwdw"));

            await _context.SaveChangesAsync();

            var actual = await _context.Notes.ToListAsync();

            actual?.Should().NotBeEmpty();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}