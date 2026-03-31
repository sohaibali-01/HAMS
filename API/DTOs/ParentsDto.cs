using System;

namespace API.DTOs;

public class ParentsDto
{
    public int Id { get; set; }

    public required string FatherName { get; set; }
    public required string FatherCnic { get; set; }

    public required string MotherName { get; set; }

    public required string PrimaryContact { get; set; }

    public required string Address { get; set; }
}
