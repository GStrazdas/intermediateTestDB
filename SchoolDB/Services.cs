using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    internal class Services
    {
        public static void Add<T>(string item)
        {
            using (var schoolContext = new SchoolContext())
            {
                switch (typeof(T).Name)
                {
                    case "Department":
                        schoolContext.Departments.Add(new Department() { Name = item });
                        break;
                    case "Lesson":
                        schoolContext.Lessons.Add(new Lesson() { Name = item });
                        break;
                    case "Student":
                        schoolContext.Students.Add(new Student() { Name = item });
                        break;
                }
                schoolContext.SaveChanges();
            }
        }
        public static void Add<T>(List<string> items)
        {
            foreach (string item in items)
            {
                Add<T>(item);
            }
        }
        public static bool CheckIfExist<T>(string item)
        {
            using (var schoolContext = new SchoolContext())
            {
                switch (typeof(T).Name)
                {
                    case "Department":
                        schoolContext.Departments.Add(new Department() { Name = item });
                        break;
                    case "Lesson":
                        schoolContext.Lessons.Add(new Lesson() { Name = item });
                        break;
                    case "Student":
                        schoolContext.Students.Add(new Student() { Name = item });
                        break;
                }
            }
            return false;
        }
    }
}
