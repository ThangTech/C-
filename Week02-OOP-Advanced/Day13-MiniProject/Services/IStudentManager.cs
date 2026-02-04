using Day13_MiniProject.Models;

namespace Day13_MiniProject.Services;

public interface IStudentManager
{
    void AddStudent(Student student);
    void UpdateStudent(int id, Student updatedStudent);
    bool DeleteStudent(int id);
    Student? GetStudentById(int id);
    IEnumerable<Student> GetAllStudents();
    IEnumerable<Student> SearchByName(string name);
    IEnumerable<Student> SortByGPA();
    IEnumerable<Student> SortByName();
    
    // File I/O
    void SaveToFile(string filePath);
    void LoadFromFile(string filePath);
}
