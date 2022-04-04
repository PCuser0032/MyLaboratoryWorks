namespace StudentActions
{
    public class MyStudent
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public string? Group { get; set; }
        public string? SpecialtyCode { get; set; }
        public bool LiveOnDormitory { get; set; }

        public static MyStudent Add(MyStudent x, MyStudent y)
        {
            MyStudent addResult = new()
            {
                Name = x.Name + y.Name,
                Surname = x.Surname + y.Surname,
                Gender = x.Gender + y.Gender,
                Age = x.Age + y.Age,
                HairColor = x.HairColor + y.HairColor,
                EyeColor = x.EyeColor + y.EyeColor,
                Height = x.Height + y.Height,
                Weight = x.Weight + y.Weight,
                Group = x.Group + y.Group,
                SpecialtyCode = x.SpecialtyCode + y.SpecialtyCode,
                LiveOnDormitory = x.LiveOnDormitory || y.LiveOnDormitory
            };

            return addResult;
        }

        public void GetInfoAboutStudent()
        {
            Console.WriteLine
            (
                $"Student info:\n" +
                $"Name: { Name }\n" +
                $"Surname: { Surname }\n" +
                $"Gender: { Gender }\n" +
                $"Age: { Age } years\n" +
                $"Hair color: { HairColor }\n" +
                $"Eye color: { EyeColor }\n" +
                $"Height: { Height } m\n" +
                $"Weight: { Weight } kg\n" +
                $"Group: { Group }\n" +
                $"Specialty code: { SpecialtyCode }\n" +
                $"Live on dormitory: { (LiveOnDormitory ? "yes" : "no") }"
            );

            Console.WriteLine();
        }
    }
}
