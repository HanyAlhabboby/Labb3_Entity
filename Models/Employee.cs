using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Courses = new HashSet<Course>();
        }

        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? FkTitelId { get; set; }

        public int? Salary { get; set; }

        public DateTime? WorkingDate { get; set; }

        public virtual Titel? FkTitel { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
