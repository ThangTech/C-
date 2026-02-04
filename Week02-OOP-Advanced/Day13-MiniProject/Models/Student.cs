namespace Day13_MiniProject.Models;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public double GPA { get; set; }

    public string HocLuc
    {
        get
        {
            if (GPA >= 8.0) return "Giỏi";
            if (GPA >= 6.5) return "Khá";
            if (GPA >= 5.0) return "Trung bình";
            return "Yếu";
        }
    }

    public Student() { }

    public Student(int id, string name, int age, Gender gender, double gpa)
    {
        Id = id;
        Name = name;
        Age = age;
        Gender = gender;
        GPA = gpa;
    }

    public override string ToString()
    {
        return $"ID: {Id,-5} | Tên: {Name,-20} | Tuổi: {Age,-3} | GT: {Gender,-10} | GPA: {GPA,-5:F1} | XL: {HocLuc}";
    }

    // Helper to convert to CSV string for saving to file
    public string ToCsv() => $"{Id},{Name},{Age},{Gender},{GPA}";

    // Helper to create Student from CSV string
    public static Student FromCsv(string csv)
    {
        var parts = csv.Split(',');
        return new Student(
            int.Parse(parts[0]),
            parts[1],
            int.Parse(parts[2]),
            Enum.Parse<Gender>(parts[3]),
            double.Parse(parts[4])
        );
    }
}
