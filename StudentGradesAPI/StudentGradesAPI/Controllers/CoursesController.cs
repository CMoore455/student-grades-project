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
    public class CoursesController : ControllerBase
    {
        private readonly StudentGradesDBContext _context;

        public CoursesController(StudentGradesDBContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<object>> GetCourses()
        {
            return new
            {
                Results = await _context
                .Courses
                .Select(c => new
                {
                    c.CourseId,
                    c.CourseName,
                    Grades = c.Grades
                   .Select(g => new
                   {
                       g.GradeId,
                       g.Letter,
                       g.Score,
                       Student = new
					   {
                           g.Student.StudentId,
                           g.Student.StudentName,
                           g.Student.Email,
                       }
                   }).ToList()
                }).ToListAsync()
            };
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetCourse(int id)
        {
            //var course = await _context.Courses.FindAsync(id);
            var course = await _context.Courses.Where(c => c.CourseId == id)
                .Select(c => new
                {
                    c.CourseId,
                    c.CourseName,
                    Grades = c.Grades
                   .Select(g => new
                   {
                       g.GradeId,
                       g.Letter,
                       g.Score,
                       Student = new
                       {
                           g.Student.StudentId,
                           g.Student.StudentName,
                           g.Student.Email,
                       }
                   }).ToList()
                }).FirstOrDefaultAsync();

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CourseExists(course.CourseId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
