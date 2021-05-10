using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGradesAPI.Models;

namespace StudentGradesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentGradesDBContext _context;

        public StudentsController(StudentGradesDBContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<object>> GetStudents()
        {
			//return await _context.Students.ToListAsync();
            return new
            {
                Results = await _context
                .Students
                .Select(s => new
                {
                   s.StudentId,
                   s.StudentName,
                   s.Email,
                   OverallGPA = CalculateOverallGPA(s.Grades),
                   Grades = s
                   .Grades
                   .Select(g => new { 
                       g.GradeId, 
                       g.Letter,
                       g.Score,
                       Course = new
					   {
                           g.Course.CourseId,
                           g.Course.CourseName
                       }
                   })
                   .ToList()
                }).ToListAsync()
            };
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetStudent(int id)
        {
            var student = await _context.Students.Where(s => s.StudentId == id)
                .Select(s=> new 
                {
                    s.StudentId,
                    s.StudentName,
                    s.Email,
                    OverallGPA = CalculateOverallGPA(s.Grades),
                    Grades = s
                   .Grades
                   .Select(g => new {
                       g.GradeId,
                       g.Letter,
                       g.Score,
                       Course = new
                       {
                           g.Course.CourseId,
                           g.Course.CourseName
                       }
                   })
                   .ToList()
                }).FirstOrDefaultAsync();
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET: api/Students/mark/grade/math
        [HttpGet("{name}/grade/{course}")]
        public async Task<ActionResult<object>> GetStudentGrade(string name, string course)
        {
            var student = await _context.Students.Where(s => s.StudentName.ToUpper().Contains(name.ToUpper()))
                .Select(s => new
                {
                    s.StudentId,
                    s.StudentName,
                    Grade = s.Grades.Where(g=> g.Course.CourseName == course)
                    .Select(g=> new
					{
                        g.GradeId,
                        g.Letter,
                        g.Score,
                        g.Course.CourseName
					})
                }).ToListAsync();
            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _context.Students.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudent", new { id = student.StudentId }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }

        private static double CalculateOverallGPA(ICollection<Grade> grades)
		{
            if(grades.Count > 0)
			{
                return grades.Select(g => g.Score).Average();

            }
            return 0;
		}
    }

}
