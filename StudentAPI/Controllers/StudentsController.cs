using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.Repo;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentRepo.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            var student = await _studentRepo.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> AddStudent([FromBody]StudentCreateDto studentDto)
        {
            if(studentDto == null)
            {
                return BadRequest();
            }
            var studentModel = _mapper.Map<Student>(studentDto);

            if(!_studentRepo.AddStudent(studentModel))
            {
                return BadRequest();
            }
            
            return CreatedAtAction(nameof(GetStudentById), new {id = studentModel.Id}, studentModel);
        }
    }
}