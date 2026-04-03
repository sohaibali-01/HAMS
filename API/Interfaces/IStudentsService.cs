using System;
using API.DTOs;

namespace API.Interfaces;

public interface IStudentsService
{
    Task<StudentDto> CreateStudentAsync(CreateStudentDto dto);
    Task<StudentDto?> GetStudentByIdAsync(int id);
    Task<IEnumerable<StudentDto>> GetAllStudentsAsync();
    Task<EnrollmentDto> CreateEnrollmentAsync(CreateEnrollmentDto dto);
}
