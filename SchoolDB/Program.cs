// intermediate test DB

using Microsoft.EntityFrameworkCore;
using SchoolDB;

Services.RemoveTableData<Student>();
Services.RemoveTableData<Lesson>();
Services.RemoveTableData<Department>();

Services.AddItem<Department>("ExistingDeparment");
Services.AddItem<Lesson>("ExistingLesson");
Services.AddItem<Student>("ExistingStudent");

Services.AddItem<Department>(new List<string>
{
    "ExistingDeparment1",
    "ExistingDeparment2",
    "ExistingDeparment3"
});

Services.AddItem<Lesson>(new List<string>
{
    "ExistingLesson1",
    "ExistingLesson2",
    "ExistingLesson3"
});

Services.AddItem<Student>(new List<string>
{
    "ExistingStudent1",
    "ExistingStudent2",
    "ExistingStudent3"
});

/****************************
 *                          *
 *      Pirmas punktas      *
 *                          *
 ****************************/
using (var schoolContext = new SchoolContext())
{
    var addDepartment = new Department()
    {
        Name = "NewDepartment",
        Lesson = new List<Lesson>()
        {
            new Lesson() { Name = "NewLesson"},
            new Lesson() { Name = "NewLesson1"},
            new Lesson(){ Name ="NewLesson2"}
        },
        Student = new List<Student>()
        {
            new Student() { Name = "NewStudent"},
            new Student() { Name = "NewStudent1"},
            new Student() { Name = "NewStudent2"},
        }
    };

    var addExistingLesson1 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson1");
    var addExistingLesson2 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson2");
    var addExistingStudent2 = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent2");
    var addExistingStudent3 = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent3");

    addDepartment.Lesson.Add(addExistingLesson1);
    addDepartment.Lesson.Add(addExistingLesson2);
    addDepartment.Student.Add(addExistingStudent2);
    addDepartment.Student.Add(addExistingStudent3);

    schoolContext.Departments.Add(addDepartment);
    schoolContext.SaveChanges();

    Console.WriteLine("/*********************   Pirmas punktas  ******************************/");
    Console.WriteLine("New Departments students");
    Services.PrintDepartmentsStudents("NewDepartment");
    Console.WriteLine("New Departments lessons");
    Services.PrintDepartmentsLessons("NewDepartment");
}

/****************************************
 *                                      *
 *      Antras - penktas punktai        *
 *                                      *
 ****************************************/
using (var schoolContext = new SchoolContext())
{
    var updateDepartment = schoolContext.Departments.FirstOrDefault(d => d.Name == "ExistingDeparment1");
    var addExistingLesson = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson");
    var addExistingLesson2 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson2");
    var addExistingLesson3 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson3");
    var addNewLesson3 = new Lesson() { Name = "NewLesson3" };
    var addExistingStudent = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent");
    var addExistingStudent2 = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent2");
    var addNewStudent3 = new Student() { Name = "NewStudent3" };

    Console.WriteLine("/*********************   Antras - Penktas punktai  ******************************/");
    Console.WriteLine("Before:");
    Console.WriteLine("Departments students");
    Services.PrintDepartmentsStudents(null);
    Console.WriteLine("Departments lessons");
    Services.PrintDepartmentsLessons(null);

    updateDepartment.Lesson.Add(addExistingLesson);
    updateDepartment.Lesson.Add(addExistingLesson2);
    updateDepartment.Lesson.Add(addExistingLesson3);
    updateDepartment.Lesson.Add(addNewLesson3);
    updateDepartment.Lesson.Add(new Lesson() { Name = "NewLesson4" });
    updateDepartment.Student.Add(addExistingStudent);
    updateDepartment.Student.Add(addExistingStudent2);
    updateDepartment.Student.Add(addNewStudent3);
    updateDepartment.Student.Add(new Student() { Name = "NewStudent4" });

    schoolContext.Departments.Update(updateDepartment);
    schoolContext.SaveChanges();

    Console.WriteLine("After");
    Console.WriteLine("Departments students before");
    Services.PrintDepartmentsStudents(null);
    Console.WriteLine("Departments lessons before");
    Services.PrintDepartmentsLessons(null);
}

/****************************************
 *                                      *
 *      Sestas - astuntas punktas       *
 *                                      *
 ****************************************/

Console.WriteLine("/*********************   Sestas - Astuntas punktai  ******************************/");
Services.PrintDepartmentsStudents("NewDepartment");
Services.PrintDepartmentsLessons("ExistingDeparment1");

Console.WriteLine("Finished");