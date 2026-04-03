using System;

namespace API.DTOs;

public class CreateEnrollmentDto
{
    public int StudentId { get; set; }
    public int SessionId { get; set; }
    public int SectionId { get; set; }
}