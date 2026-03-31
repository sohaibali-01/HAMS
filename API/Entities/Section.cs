using System;

namespace API.Entities;

public class Section
{
    public int Id { get; set; }
    public string Name { get; set; } // "A", "B"

    public int ClassId { get; set; }
    public Class Class { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
