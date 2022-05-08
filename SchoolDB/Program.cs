// intermediate test DB

using SchoolDB;

Services.Add<Department>("TestDeparment");
Services.Add<Lesson>("TestLesson");
Services.Add<Student>("TestStudent");

Services.Add<Department>(new List<string>
{
    "TestDeparment1",
    "TestDeparment2",
    "TestDeparment3"
});

Services.Add<Lesson>(new List<string>
{
    "TestLesson1",
    "TestLesson2",
    "TestLesson3"
});

Services.Add<Student>(new List<string>
{
    "TestStudent1",
    "TestStudent2",
    "TestStudent3"
});























// New Department
/*using (var schoolContext = new SchoolContext())
{
    var department = new Department() { Name = "Informatic" };

    schoolContext.Departments.Add(department);
    schoolContext.SaveChanges();
}*/


// New Lesson
/*using (var schoolContext = new SchoolContext())
{
    var lesson = new Lesson() { Name = "Programing" };

    schoolContext.Lessons.Add(lesson);
    schoolContext.SaveChanges();
}*/

// New Student
/*using (var schoolContext = new SchoolContext())
{
    var student = new Student() { Name = "Jonas" };

    schoolContext.Students.Add(student);
    schoolContext.SaveChanges();
}*/

Console.WriteLine("Finished");