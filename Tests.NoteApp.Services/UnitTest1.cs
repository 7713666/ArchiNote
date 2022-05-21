using NoteApp.Infrastructure.Data;
using NoteApp.Services;

namespace Tests.NoteApp.Services;

public class Tests
{
    private ExampleService _service;
    // private NoteContext _context;

    [SetUp]
    public void Setup()
    {
        // _context = new NoteContext(null);
        _service = new ExampleService();
    }

    [TearDown]
    public void TearDown()
    {
        // _context.Dispose();
    }

    [TestCase(1, 2, 3)]
    [TestCase(3, 4, 7)]
    [TestCase(3, 9, 12)]
    [TestCase(-1, 9, 0)]
    public void AddNoteAsync_Should_ReturnNote_When_AddCalled(int a, int b, int expected)
    {
        var actual = _service.Sum(a, b);
        
        Assert.AreEqual(expected, actual);
    }

    [TestCase(1, 2, 2)]
    [TestCase(3, 4, 12)]
    [TestCase(3, 9, 27)]
    public void Multiply_Should_MultiplyTwoParametes(int a, int b, int expected)
    {
        
        var actual = _service.Multiply(a, b);
        
        Assert.AreEqual(expected, actual);
    }
}