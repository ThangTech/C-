using Day13_MiniProject.Models;

namespace Day13_MiniProject.Services;

public class StudentManager : IStudentManager
{
    private List<Student> _students = new List<Student>();

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public void UpdateStudent(int id, Student updatedStudent)
    {
        var existing = GetStudentById(id);
        if (existing != null)
        {
            existing.Name = updatedStudent.Name;
            existing.Age = updatedStudent.Age;
            existing.Gender = updatedStudent.Gender;
            existing.GPA = updatedStudent.GPA;
        }
    }

    public bool DeleteStudent(int id)
    {
        var student = GetStudentById(id);
        if (student != null)
        {
            _students.Remove(student);
            return true;
        }
        return false;
    }

    public Student? GetStudentById(int id)
    {
        return _students.FirstOrDefault(s => s.Id == id);
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _students.ToList();
    }

    public IEnumerable<Student> SearchByName(string name)
    {
        return _students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Student> SortByGPA()
    {
        return _students.OrderByDescending(s => s.GPA);
    }

    public IEnumerable<Student> SortByName()
    {
        return _students.OrderBy(s => s.Name);
    }

    public void SaveToFile(string filePath)
    {
        try
        {
            var lines = _students.Select(s => s.ToCsv());
            File.WriteAllLines(filePath, lines);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Lỗi khi lưu file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filePath)
    {
        if (!File.Exists(filePath)) return;

        try
        {
            var lines = File.ReadAllLines(filePath);
            _students = lines.Select(line => Student.FromCsv(line)).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Lỗi khi đọc file: {ex.Message}");
            _students = new List<Student>();
        }
    }
}
