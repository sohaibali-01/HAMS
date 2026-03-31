using System;

namespace API.DTOs;

public class CreateParentsDto
{
    public required string FatherName { get; set; }
    public required string FatherNameUrdu { get; set; }
    public required string FatherCnic { get; set; }
    public required string FatherOccupation { get; set; }
    public required string FatherQualification { get; set; }

    public required string MotherName { get; set; }
    public required string MotherNameUrdu { get; set; }
    public required string MotherQualification { get; set; }
    public required string MotherOccupation { get; set; }

    public required string PrimaryContact { get; set; }

    public string? SecondaryContact { get; set; }
    public string? LandlineNumber { get; set; }

    public required string Address { get; set; }
    public string? ExtraNote { get; set; }
}
