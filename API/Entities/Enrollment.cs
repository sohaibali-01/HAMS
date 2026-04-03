using System;

namespace API.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int SessionId { get; set; }
    public Session Session { get; set; } = null!;

    public int SectionId { get; set; }
    public Section Section { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
