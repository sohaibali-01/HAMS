using System;

namespace API.Entities;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } = null!; // "A", "B"

    public int ClassId { get; set; }
    public Class Class { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
