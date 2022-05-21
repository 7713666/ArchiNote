using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NoteApp.Domain.Core;
using NoteApp.Infrastructure.Data;
using NoteApp.Services.Services;

namespace Tests.NoteApp.Services;

public class NoteRepositoryStub : INoteRepository
{
    public Task<IEnumerable<Note>> GetAsync()
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

    public async Task<Note?> DeleteAsync(int id)
    {
        return new Note(1, "adwwd", "awdawd", new List<NoteFile>());
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
    public async Task AddNoteAsync_Should_ReturnNote_When_AddCalled()
    {
        _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(new Note(1, "adwwd", "awdawd", new List<NoteFile>()));
        
        var actual = await _service.DeleteNoteAsync(1);
        
        actual.Should().NotBeNull();
        // Assert.IsNotNull(actual);
    }
    
    [Test]
    public async Task AddNoteAsync_Should_ReturnNote_When_NoFilesProvided()
    {
        _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(new Note(1, "adwwd", "awdawd", new List<NoteFile>()));
        
        var actual = await _service.DeleteNoteAsync(1);

        actual.Files.Should().NotBeEmpty();
    }
    
    [Test]
    public async Task AddNoteAsync_Should_ReturnNote_When_HasFiles()
    {
        var note = new Note(1, "adwwd", "awdawd", new List<NoteFile>()
        {
            new NoteFile(1, "awdawd", "awdaw", null),
            new NoteFile(2, "xvxc", "xcvcx", null),
        });

        _repositoryMock.Setup(x => x.DeleteAsync(It.IsAny<int>()))
            .ReturnsAsync(note);
        
        var actual = await _service.DeleteNoteAsync(1);
        
        _repositoryMock.Verify(x=>x.DeleteAsync(1), Times.Once);
        actual.Files.Should().HaveCount(2)
            .And.Satisfy(
                x => x.Id == 1, 
                x => x.Id == 2);
        // Assert.AreEqual(2, actual.Files.Count);
    }
}

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
    public void TearDown()
    {
        _context.Database.EnsureDeletedAsync();
    }

    [Test]
    public async Task AddNoteAsync_Should_ReturnNote_When_AddCalled()
    {
        await _context.Notes.AddAsync(new Note(1, "wadaw", "adwdw"));
        await _context.SaveChangesAsync();
        
        var actual = await _service.DeleteNoteAsync(1);
        
        Assert.IsNotNull(actual);
    }
} 