int n = int.Parse(Console.ReadLine());

List<Student> classRoom = new List<Student>();

for (int i = 0; i < n; i++)
{
    //"{first name} {second name} {grade}"
    string[] studentInfo = Console.ReadLine().Split(" ");

    string firstName = studentInfo[0];
    string lastName = studentInfo[1];
    double grade = double.Parse(studentInfo[2]);

    // create new instance ot class Student
    Student currentStudent = new Student(firstName, lastName, grade);

    // add student to List of students (class room)
    classRoom.Add(currentStudent);
}

                                    // sort classRoom in descendig order by student grade
foreach (Student student in classRoom.OrderByDescending(s => s.Grade))
{
    Console.WriteLine($"{student.FirsName} {student.LastName}: {student.Grade:F2}");
}

class Student
{
    public Student(string firstName, string lastName, double grade)
    {
        FirsName = firstName;
        LastName = lastName;
        Grade = grade;
    }

    public string FirsName { get; set; }

    public string LastName { get; private set; }

    public double Grade { get; private set; }
}
