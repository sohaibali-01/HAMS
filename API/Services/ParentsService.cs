using System;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public class ParentsService(AppDbContext _context) : IParentsService
{
    

    public async Task<ParentsDto> CreateParentAsync(CreateParentsDto dto)
    {
        Validate(dto);

        var existing = await _context.Parents
            .FirstOrDefaultAsync(p => p.FatherCnic == dto.FatherCnic);

        if (existing != null)
            throw new InvalidOperationException("Parent already exists");

        //  Map
        var parent = new Parents
        {
            FatherName = dto.FatherName,
            FatherNameUrdu = dto.FatherNameUrdu,
            FatherCnic = dto.FatherCnic,
            FatherOccupation = dto.FatherOccupation,
            FatherQualification = dto.FatherQualification,

            MotherName = dto.MotherName,
            MotherNameUrdu = dto.MotherNameUrdu,
            MotherQualification = dto.MotherQualification,
            MotherOccupation = dto.MotherOccupation,

            PrimaryContact = dto.PrimaryContact,
            SecondaryContact = dto.SecondaryContact,
            LandlineNumber = dto.LandlineNumber,

            Address = dto.Address,
            ExtraNote = dto.ExtraNote
        };

        _context.Parents.Add(parent);
        await _context.SaveChangesAsync();

        return new ParentsDto
        {
            Id = parent.Id,
            FatherName = parent.FatherName,
            FatherCnic = parent.FatherCnic,
            MotherName = parent.MotherName,
            PrimaryContact = parent.PrimaryContact,
            Address = parent.Address
        };
    }

    public async Task<ParentsDto?> GetParentByIdAsync(int id)
    {
        var parent = await _context.Parents.FindAsync(id);

        if (parent == null) return null;

        return new ParentsDto
        {
            Id = parent.Id,
            FatherName = parent.FatherName,
            FatherCnic = parent.FatherCnic,
            MotherName = parent.MotherName,
            PrimaryContact = parent.PrimaryContact,
            Address = parent.Address
        };
    }

        private static void Validate(CreateParentsDto dto)
    {
        // CNIC
        if (string.IsNullOrWhiteSpace(dto.FatherCnic) ||
            dto.FatherCnic.Length != 13 ||
            !dto.FatherCnic.All(char.IsDigit))
        {
            throw new ArgumentException("Invalid CNIC");
        }

        // Phone
        if (string.IsNullOrWhiteSpace(dto.PrimaryContact) ||
            dto.PrimaryContact.Length < 10 ||
            !dto.PrimaryContact.All(char.IsDigit))
        {
            throw new ArgumentException("Invalid phone number");
        }
    }
}
