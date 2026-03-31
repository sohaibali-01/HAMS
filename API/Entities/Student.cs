using System;

namespace API.Entities;

public class Student
{
    public int Id { get; set; }

    public required string FullName { get; set; }
    public required string FullNameUrdu { get; set; }

    public required string BForm { get; set; }
    public required string AdmissionNo { get; set; }
    public required string RegistrationNo { get; set; }
    public required string Gender { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string DateOfBirthInWords { get; set; }
    public required DateTime AdmissionDate { get; set; }
    public DateTime EntryDate { get; set; }
    public string? PreviousSchool { get; set; }
    public string? MarkOfIdentification { get; set; }
    public required bool HifzEQuran { get; set; }
    

    // 🔥 FK → Parents
    public int ParentsId { get; set; }
    public Parents Parents { get; set; } = null!;

    public ICollection<Enrollment> Enrollments { get; set; } = [];
}


