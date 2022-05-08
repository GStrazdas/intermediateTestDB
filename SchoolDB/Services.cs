using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDB
{
    internal class Services
    {
        /// <summary>
        /// Add T type element to a table if elements name doesn't exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public static void AddItem<T>(string item)
        {
            using (var schoolContext = new SchoolContext())
            {
                switch (typeof(T).Name)
                {
                    case "Department":
                        if (!CheckIfExist<Department>(item))
                        {
                            schoolContext.Departments.Add(new Department() { Name = item });
                        }
                        break;
                    case "Lesson":
                        if (!CheckIfExist<Lesson>(item))
                        {
                            schoolContext.Lessons.Add(new Lesson() { Name = item });
                        }
                        break;
                    case "Student":
                        if (!CheckIfExist<Student>(item))
                        {
                            schoolContext.Students.Add(new Student() { Name = item });
                        }
                        break;
                }
                schoolContext.SaveChanges();
            }
        }
        /// <summary>
        /// Add list of T type to a table if elements name doesn't exist
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        public static void AddItem<T>(List<string> items)
        {
            foreach (string item in items)
            {
                AddItem<T>(item);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool CheckIfExist<T>(string item)
        {
            using (var schoolContext = new SchoolContext())
            {
                switch (typeof(T).Name)
                {
                    case "Department":
                        if(schoolContext.Departments.Where(d => d.Name == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                    case "Lesson":
                        if (schoolContext.Lessons.Where(l => l.Name == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                    case "Student":
                        if (schoolContext.Students.Where(s => s.Name == item).Count() > 0)
                        {
                            return true;
                        }
                        break;
                }
            }
            return false;
        }
        public static void RemoveTableData<T>()
        {
            using (var schoolContext = new SchoolContext())
            {
                switch (typeof(T).Name)
                {
                    case "Department":
                        var removeDepartment = schoolContext.Departments;
                        foreach (var department in removeDepartment)
                        {
                            schoolContext.Departments.Remove(department);
                        }
                        break;
                    case "Lesson":
                        var removeLesson = schoolContext.Lessons;
                        foreach (var lesson in removeLesson)
                        {
                            schoolContext.Lessons.Remove(lesson);
                        }
                        break;
                    case "Student":
                        var removeStudent = schoolContext.Students;
                        foreach (var student in removeStudent)
                        {
                            schoolContext.Students.Remove(student);
                        }
                        break;
                }
                schoolContext.SaveChanges();
            }
        }
        /// <summary>
        /// parameter null - print all departments
        /// </summary>
        /// <param name="department"></param>
        public static void PrintDepartmentsStudents(string departmentsName)
        {
            using (var schoolContext = new SchoolContext())
            {
                var departmentsStudents = schoolContext.Departments.Where(d => departmentsName != null ? d.Name == departmentsName : true).Include(d => d.Student);
                foreach (var department in departmentsStudents)
                {
                    Console.WriteLine($"{department.Name} departments students:");
                    var studentList = department.Student;
                    foreach (var student in studentList)
                    {
                        Console.WriteLine($"\t{student.Name}");
                    }
                }
            }
        }
        /// <summary>
        /// parameter null - print all departments
        /// </summary>
        /// <param name="department"></param>
        public static void PrintDepartmentsLessons(string departmentsName)
        {
            using (var schoolContext = new SchoolContext())
            {
                var departmentsLessons = schoolContext.Departments.Where(d => departmentsName != null ? d.Name == departmentsName : true).Include(d => d.Lesson);
                foreach (var department in departmentsLessons)
                {
                    Console.WriteLine($"{department.Name} departments lessons:");
                    var lessonsList = department.Lesson;
                    foreach (var lesson in lessonsList)
                    {
                        Console.WriteLine($"\t{lesson.Name}");
                    }
                }
            }
        }
    }
}
