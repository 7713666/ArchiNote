using Microsoft.AspNetCore.Mvc;
using NoteApp.Infrastructure.Data;

namespace ArchiNote.Controllers;

public abstract class ApiController : ControllerBase
{
    protected readonly NoteContext Db;

    public ApiController(NoteContext noteContext)
    {
        Db = noteContext;
    }
}