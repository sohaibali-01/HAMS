using System;

namespace API.Entities;

public class Session
{
    public int Id { get; set; }
    public string Name { get; set; } // "2025-2026"

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
