using System;

namespace API.DTOs;

public class SectionDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int ClassId { get; set; }
}
