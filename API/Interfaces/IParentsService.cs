using System;
using API.DTOs;

namespace API.Interfaces;

public interface IParentsService
{
    Task<ParentsDto> CreateParentAsync(CreateParentsDto dto);
    Task<ParentsDto?> GetParentByIdAsync(int id);
}
