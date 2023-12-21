using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public int? FkEmployee { get; set; }
        public string? CourseName { get; set; }

        public virtual Employee? FkEmployeeNavigation { get; set; }
    }
}
