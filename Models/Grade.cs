using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class Grade
    {
        public DateTime? GradeDate { get; set; }
        public int? FkStudentId { get; set; }
        public int? FkCourseId { get; set; }
        public string? GradeInfo { get; set; }

        public int? GradeID { get; set; }

        public virtual Course? FkCourse { get; set; }
        public virtual Student? FkStudent { get; set; }
    }
}
