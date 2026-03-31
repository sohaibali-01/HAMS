using System;

namespace API.Entities;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }

    public int SessionId { get; set; }
    public Session Session { get; set; }

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public int SectionId { get; set; }
    public Section Section { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
