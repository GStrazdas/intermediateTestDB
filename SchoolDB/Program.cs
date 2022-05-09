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
            new Lesson(){ Name ="NewLesson2"},
            schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson1")
        },
        Student = new List<Student>()
        {
            new Student() { Name = "NewStudent"},
            new Student() { Name = "NewStudent1"},
            new Student() { Name = "NewStudent2"},
            schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent2")
        }
    };

    var addExistingLesson2 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson2");
    var addExistingStudent3 = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent3");

    addDepartment.Lesson.Add(addExistingLesson2);
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
    var addExistingLesson = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson");          // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    var addExistingLesson2 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson2");        // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    var addExistingLesson3 = schoolContext.Lessons.FirstOrDefault(l => l.Name == "ExistingLesson3");        // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    var addNewLesson3 = new Lesson() { Name = "NewLesson3" };                                               // 3. Sukurti paskaitą ir ją priskirti prie departamento.
    var addExistingStudent = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent");       // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    var addExistingStudent2 = schoolContext.Students.FirstOrDefault(s => s.Name == "ExistingStudent2");     // 5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos). Studentas buvo pirmame punkte priskirtas NewDepartment departamentui
    var addNewStudent3 = new Student() { Name = "NewStudent3" };

    Console.WriteLine("/*********************   Antras - Penktas punktai  ******************************/");
    Console.WriteLine("Before:");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Departments students");
    Services.PrintDepartmentsStudents(null);
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Departments lessons");
    Services.PrintDepartmentsLessons(null);
    Console.WriteLine("-----------------------------------------------");
    Services.PrintStudentLessons("ExistingStudent2");

    updateDepartment.Lesson.Add(addExistingLesson);                         // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    updateDepartment.Lesson.Add(addExistingLesson2);                        // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    updateDepartment.Lesson.Add(addExistingLesson3);                        // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    updateDepartment.Lesson.Add(addNewLesson3);                             // 3. Sukurti paskaitą ir ją priskirti prie departamento.
    updateDepartment.Lesson.Add(new Lesson() { Name = "NewLesson4" });      // 3. Sukurti paskaitą ir ją priskirti prie departamento.
    updateDepartment.Student.Add(addExistingStudent);                       // 2. Pridėti studentus/paskaitas į jau egzistuojantį departamentą.
    updateDepartment.Student.Add(addExistingStudent2);                      // 5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos). Studentas buvo pirmame punkte priskirtas NewDepartment departamentui
    updateDepartment.Student.Add(addNewStudent3);                           // 4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.
    updateDepartment.Student.Add(new Student() { Name = "NewStudent4" });   // 4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.

    schoolContext.Departments.Update(updateDepartment);
    schoolContext.SaveChanges();

    Console.WriteLine("After");
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Departments students");
    Services.PrintDepartmentsStudents(null);
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Departments lessons");
    Services.PrintDepartmentsLessons(null);
    Console.WriteLine("-----------------------------------------------");
    Services.PrintStudentLessons("ExistingStudent2");
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