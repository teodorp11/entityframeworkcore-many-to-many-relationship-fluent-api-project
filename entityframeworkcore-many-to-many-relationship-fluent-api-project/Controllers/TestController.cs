using entityframeworkcore_many_to_many_relationship_fluent_api_project.Models;
using entityframeworkcore_many_to_many_relationship_project.Models;
using entityframeworkcore_many_to_many_relationship_project.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace entityframeworkcore_many_to_many_relationship_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly Repository _repository;

        public TestController(Repository repository)
        {
            this._repository = repository;
        }

        [HttpGet("get-subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var subjects = await _repository.GetSubjects();
            return Ok(subjects);
        }

        [HttpPost("add-subject")]
        public async Task<IActionResult> AddSubject(Subject subject)
        {
            await _repository.AddSubject(subject);
            return Ok("Action completed successfully.");
        }

        [HttpGet("get-students")]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _repository.GetStudents());
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _repository.AddStudent(student);
            return Ok("Action completed successfully.");
        }

        [HttpGet("get-students-subjects")]
        public async Task<IActionResult> GetStudentSubjects()
        {
            return Ok(await _repository.GetStudentSubjects());
        }

        [HttpPost("add-student-subject")]
        public async Task<IActionResult> AddStudentSubject(StudentIDSubjectID studentIDSubjectID)
        {
            await _repository.AddStudentSubject(studentIDSubjectID);
            return Ok("Action completed successfully.");
        }
    }
}