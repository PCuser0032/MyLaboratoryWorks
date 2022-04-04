using StudentActions;

Console.WriteLine("StudentApp. Implementation actions with students on C#");
Console.WriteLine("Created by Kozlov D., group VPI-31");

Console.WriteLine();

MyStudent student1 = new MyStudent()
{
    Name = "Владимир",
    Surname = "Копылов",
    Gender = "м",
    Age = 31,
    HairColor = "Каштановый",
    EyeColor = "Голубой",
    Height = 1.85f,
    Weight = 74.5f,
    Group = "ВИС-41",
    SpecialtyCode = "08.03.01",
    LiveOnDormitory = true
};

MyStudent student2 = new()
{
    Name = "Ольга",
    Surname = "Морозова",
    Gender = "ж",
    Age = 19,
    HairColor = "Блонд",
    EyeColor = "Карий",
    Height = 1.61f,
    Weight = 53.3f,
    Group = "ВПР-11",
    SpecialtyCode = "02.03.04",
    LiveOnDormitory = false
};

MyStudent student3 = new()
{
    Name = "Валерия",
    Surname = "Скрипка",
    Gender = "м",
    Age = 25,
    HairColor = "Русый",
    EyeColor = "Зелёный",
    Height = 1.59f,
    Weight = 48.9f,
    Group = "ВИАС-33",
    SpecialtyCode = "10.03.04",
    LiveOnDormitory = true
};

// Get info about one student
// MyStudent.GetInfoAboutStudent(student1);
student1.GetInfoAboutStudent();

// Get info about addition two students
// MyStudent.GetInfoAboutStudent(MyStudent.Add(student2, student3));
MyStudent.Add(student2, student3).GetInfoAboutStudent();

// // Get info about addition three students
// MyStudent.GetInfoAboutStudent(MyStudent.Add(student1, MyStudent.Add(student2, student3)));
MyStudent.Add(student1, MyStudent.Add(student2, student3)).GetInfoAboutStudent();