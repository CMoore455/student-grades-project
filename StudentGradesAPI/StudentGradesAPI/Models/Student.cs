using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace StudentGradesAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            Grades = new HashSet<Grade>();
        }

        [Key]
        [Column("StudentID")]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public string Email { get; set; }

        [InverseProperty(nameof(Grade.Student))]
        public virtual ICollection<Grade> Grades { get; set; }

        [NotMapped]
        public double OverallGPA { get; set; }

	}
}
