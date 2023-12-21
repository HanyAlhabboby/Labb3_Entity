using System;
using System.Collections.Generic;

namespace Labb3_Entity.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
    }
}
