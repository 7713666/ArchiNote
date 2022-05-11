using System.ComponentModel.DataAnnotations;

public class NoteViewModel
{
    
    [Required]
    [MaxLength(30)]
    public string Head { get; set; }

    public string Body { get; set; }
    public int Id { get; set; }
}