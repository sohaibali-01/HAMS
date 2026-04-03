using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class AcademicsService : IAcademicService
{
    private readonly AppDbContext _context;

    public AcademicsService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<ClassDto>> GetClassesAsync()
    {
        return await _context.Classes
            .Select(c => new ClassDto
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToListAsync();
    }

    public async Task<ClassDto> CreateClassAsync(CreateClassDto dto)
    {
        var entity = new Class
        {
            Name = dto.Name
        };

        _context.Classes.Add(entity);
        await _context.SaveChangesAsync();

        return new ClassDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }


    public async Task<List<SectionDto>> GetSectionsAsync()
    {
        return await _context.Sections
            .Select(s => new SectionDto
            {
                Id = s.Id,
                Name = s.Name,
                ClassId = s.ClassId
            })
            .ToListAsync();
    }

    public async Task<SectionDto> CreateSectionAsync(CreateSectionDto dto)
    {
        // 1️⃣ Check if the Class exists
        var clsExists = await _context.Classes.AnyAsync(c => c.Id == dto.ClassId);
        if (!clsExists)
            throw new Exception("Class not found");  // stops here if invalid

        // 2️⃣ Optional: check if section with same name already exists in this class
        var exists = await _context.Sections
            .AnyAsync(s => s.ClassId == dto.ClassId && s.Name == dto.Name);
        if (exists)
            throw new Exception("Section already exists in this class");

        var entity = new Section
        {
            Name = dto.Name,
            ClassId = dto.ClassId
        };

        _context.Sections.Add(entity);
        await _context.SaveChangesAsync();

        return new SectionDto
        {
            Id = entity.Id,
            Name = entity.Name,
            ClassId = entity.ClassId
        };
    }


    public async Task<List<SessionDto>> GetSessionsAsync()
    {
        return await _context.Sessions
            .Select(s => new SessionDto
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToListAsync();
    }

    public async Task<SessionDto> CreateSessionAsync(CreateSessionDto dto)
    {
        var entity = new Session
        {
            Name = dto.Name
        };

        _context.Sessions.Add(entity);
        await _context.SaveChangesAsync();

        return new SessionDto
        {
            Id = entity.Id,
            Name = entity.Name
        };
    }
}
