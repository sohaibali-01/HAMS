using Microsoft.AspNetCore.Mvc;
using API.Interfaces;
using API.DTOs;

namespace API.Controllers
{


    [Route("api/academic")]
    [ApiController]

    public class AcademicController : ControllerBase
    {
        private readonly IAcademicService _service;

        public AcademicController(IAcademicService service)
        {
            _service = service;
        }

        
        [HttpGet("classes")]
        public async Task<IActionResult> GetClasses()
            => Ok(await _service.GetClassesAsync());

        [HttpPost("classes")]
        public async Task<IActionResult> CreateClass(CreateClassDto dto)
            => Ok(await _service.CreateClassAsync(dto));

        
        [HttpGet("sections")]
        public async Task<IActionResult> GetSections()
            => Ok(await _service.GetSectionsAsync());

        [HttpPost("sections")]
        public async Task<IActionResult> CreateSection(CreateSectionDto dto)
            => Ok(await _service.CreateSectionAsync(dto));

        
        [HttpGet("sessions")]
        public async Task<IActionResult> GetSessions()
            => Ok(await _service.GetSessionsAsync());

        [HttpPost("sessions")]
        public async Task<IActionResult> CreateSession(CreateSessionDto dto)
            => Ok(await _service.CreateSessionAsync(dto));
    }
}
