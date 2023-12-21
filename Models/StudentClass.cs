using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class StudentClass
    {
        public int? FkStudentId { get; set; }
        public int? FkClassId { get; set; }

        public virtual Class? FkClass { get; set; }
        public virtual Student? FkStudent { get; set; }
    }
}
