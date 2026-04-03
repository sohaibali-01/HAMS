using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.DTOs;
using API.Interfaces;

namespace API.Controllers
{

    [Route("api/student")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _service;

        public StudentsController(IStudentsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentDto dto)
        {
            var student = await _service.CreateStudentAsync(dto);
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        [HttpPost("enrollment")]
        public async Task<IActionResult> CreateEnrollment(CreateEnrollmentDto dto)
        {
            var enrollment = await _service.CreateEnrollmentAsync(dto);
            return Ok(enrollment);
        }
    }
}
