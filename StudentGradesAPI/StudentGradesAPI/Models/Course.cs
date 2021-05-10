using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StudentGradesAPI.Models
{
    public partial class Course
    {
        public Course()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        [Column("CourseID")]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        [InverseProperty(nameof(Grade.Course))]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
