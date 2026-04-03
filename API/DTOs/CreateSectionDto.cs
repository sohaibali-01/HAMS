using System;

namespace API.DTOs;

public class CreateSectionDto
{
    public string Name { get; set; } = null!;
    public int ClassId { get; set; }
}
