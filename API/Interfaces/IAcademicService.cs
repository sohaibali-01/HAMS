using System;
using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IAcademicService
{
    Task<List<ClassDto>> GetClassesAsync();
    Task<ClassDto> CreateClassAsync(CreateClassDto dto);

    Task<List<SectionDto>> GetSectionsAsync();
    Task<SectionDto> CreateSectionAsync(CreateSectionDto dto);

    Task<List<SessionDto>> GetSessionsAsync();
    Task<SessionDto> CreateSessionAsync(CreateSessionDto dto);
}
