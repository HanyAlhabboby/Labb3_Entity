using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class ClassCourse
    {
        public int? FkClassId { get; set; }
        public int? FkCourseId { get; set; }

        public virtual Class? FkClass { get; set; }
        public virtual Course? FkCourse { get; set; }
    }
}
