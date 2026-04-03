using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.DTOs;

public class StudentsService : IStudentsService
{
    private readonly AppDbContext _context;

    public StudentsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StudentDto> CreateStudentAsync(CreateStudentDto dto)
    {
        var parent = await _context.Parents.FindAsync(dto.ParentsId);
        if (parent == null) throw new Exception("Parent not found");

        var student = new Student
        {
            FullName = dto.FullName,
            FullNameUrdu = dto.FullNameUrdu,
            BForm = dto.BForm,
            AdmissionNo = dto.AdmissionNo,
            RegistrationNo = dto.RegistrationNo,
            Gender = dto.Gender,
            DateOfBirth = dto.DateOfBirth,
            DateOfBirthInWords = dto.DateOfBirthInWords,
            AdmissionDate = dto.AdmissionDate,
            PreviousSchool = dto.PreviousSchool,
            MarkOfIdentification = dto.MarkOfIdentification,
            HifzEQuran = dto.HifzEQuran,
            ParentsId = dto.ParentsId
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();

        return new StudentDto
        {
            Id = student.Id,
            FullName = student.FullName,
            FullNameUrdu = student.FullNameUrdu,
            BForm = student.BForm,
            AdmissionNo = student.AdmissionNo,
            RegistrationNo = student.RegistrationNo,
            Gender = student.Gender,
            DateOfBirth = student.DateOfBirth,
            DateOfBirthInWords = student.DateOfBirthInWords,
            AdmissionDate = student.AdmissionDate,
            EntryDate = student.EntryDate,
            PreviousSchool = student.PreviousSchool,
            MarkOfIdentification = student.MarkOfIdentification,
            HifzEQuran = student.HifzEQuran,
            ParentsId = student.ParentsId,
            ParentName = parent.FatherName
        };
    }

    public async Task<StudentDto?> GetStudentByIdAsync(int id)
    {
        var student = await _context.Students
                .Include(s => s.Parents)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Session)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Section)
                        .ThenInclude(s => s.Class)
                .FirstOrDefaultAsync(s => s.Id == id);

        if (student == null) return null;

        return MapStudentDto(student);
    }

    public async Task<IEnumerable<StudentDto>> GetAllStudentsAsync()
    {
        var students = await _context.Students
                .Include(s => s.Parents)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Session)
                .Include(s => s.Enrollments)
                    .ThenInclude(e => e.Section)
                        .ThenInclude(s => s.Class)
                .ToListAsync();

        return students.Select(MapStudentDto);
    }

    public async Task<EnrollmentDto> CreateEnrollmentAsync(CreateEnrollmentDto dto)
    {
        // 1️⃣ Validate Student exists
        var studentExists = await _context.Students.AnyAsync(s => s.Id == dto.StudentId);
        if (!studentExists)
            throw new Exception("Student not found");

        // 2️⃣ Validate Section exists (including Class)
        var section = await _context.Sections
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == dto.SectionId);
        if (section == null)
            throw new Exception("Section not found");

        // 3️⃣ Validate Session exists
        var sessionExists = await _context.Sessions.AnyAsync(s => s.Id == dto.SessionId);
        if (!sessionExists)
            throw new Exception("Session not found");

        // 4️⃣ Check if student is already enrolled in this session
        var alreadyEnrolled = await _context.Enrollments
            .AnyAsync(e => e.StudentId == dto.StudentId && e.SessionId == dto.SessionId);
        if (alreadyEnrolled)
            throw new Exception("Student already enrolled in this session");

        // 5️⃣ Create Enrollment
        var enrollment = new Enrollment
        {
            StudentId = dto.StudentId,
            SectionId = dto.SectionId,
            SessionId = dto.SessionId
        };

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        // 6️⃣ Return DTO
        return new EnrollmentDto
        {
            Id = enrollment.Id,
            SessionName = (await _context.Sessions.FindAsync(dto.SessionId))!.Name,
            ClassName = section.Class.Name,
            SectionName = section.Name
        };
    }

    private static StudentDto MapStudentDto(Student student)
    {
        return new StudentDto
        {
            Id = student.Id,
            FullName = student.FullName,
            FullNameUrdu = student.FullNameUrdu,
            BForm = student.BForm,
            AdmissionNo = student.AdmissionNo,
            RegistrationNo = student.RegistrationNo,
            Gender = student.Gender,
            DateOfBirth = student.DateOfBirth,
            DateOfBirthInWords = student.DateOfBirthInWords,
            AdmissionDate = student.AdmissionDate,
            EntryDate = student.EntryDate,
            PreviousSchool = student.PreviousSchool,
            MarkOfIdentification = student.MarkOfIdentification,
            HifzEQuran = student.HifzEQuran,
            ParentsId = student.ParentsId,
            ParentName = student.Parents.FatherName,

            Enrollments = [.. student.Enrollments.Select(e => new EnrollmentDto
            {
                Id = e.Id,
                SessionName = e.Session.Name,
                ClassName = e.Section.Class.Name,
                SectionName = e.Section.Name
            })]
        };
    }
}