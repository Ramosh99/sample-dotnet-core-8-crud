using Microsoft.AspNetCore.Mvc;
using webappAPI.Services;
using webappAPI.Models;


namespace webappAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Students>>> GetAll()
        {
            var students = await _studentService.AllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> Get(int id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Students student)
        {
            await _studentService.UpdateStudent(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Students student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }

            await _studentService.AddStudent(student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
