using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    internal class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Lesson> Lesson { get; set; } = new List<Lesson>();
        public List<Student> Student { get; set; } = new List<Student>();
    }
}
