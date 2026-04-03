using System;

namespace API.DTOs;

public class EnrollmentDto
{
    public int Id { get; set; }
    public string SessionName { get; set; } = null!;
    public string ClassName { get; set; } = null!;
    public string SectionName { get; set; } = null!;
}
