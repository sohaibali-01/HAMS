using System;

namespace API.DTOs;

public class StudentDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string FullNameUrdu { get; set; } = null!;
    public string BForm { get; set; } = null!;
    public string AdmissionNo { get; set; } = null!;
    public string RegistrationNo { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string DateOfBirthInWords { get; set; } = null!;
    public DateTime AdmissionDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? PreviousSchool { get; set; }
    public string? MarkOfIdentification { get; set; }
    public bool HifzEQuran { get; set; }
    public int ParentsId { get; set; }
    public string ParentName { get; set; } = null!;

    public List<EnrollmentDto> Enrollments { get; set; } = [];
}
