using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    internal class Lesson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Department> Department { get; set; } = new List<Department>();
    }
}