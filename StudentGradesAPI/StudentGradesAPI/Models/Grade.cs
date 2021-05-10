using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StudentGradesAPI.Models
{
    public partial class Grade
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("GradeID")]
        public int GradeId { get; set; }
        [Column("CourseID")]
        public int? CourseId { get; set; }
        [Column("StudentID")]
        public int? StudentId { get; set; }
        public int Score { get; set; }
        public string Letter { get; set; }

        [ForeignKey(nameof(CourseId))]
        [InverseProperty("Grades")]
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Grades")]
        public virtual Student Student { get; set; }
    }
}
