using API.DTOs;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/parent")]
public class ParentController : ControllerBase
{
    private readonly IParentsService _service;

    public ParentController(IParentsService service)
    {
        _service = service;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateParentsDto dto)
    {
        var result = await _service.CreateParentAsync(dto);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _service.GetParentByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }
}
