using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class Titel
    {
        public Titel()
        {
            Employees = new HashSet<Employee>();
        }

        public int TitelId { get; set; }
        public string? Titel1 { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
