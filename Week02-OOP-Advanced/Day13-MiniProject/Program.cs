using Day13_MiniProject.Models;
using Day13_MiniProject.Services;

// Cấu hình
const string dataFile = "students.txt";
IStudentManager manager = new StudentManager();

// Load dữ liệu cũ nếu có
manager.LoadFromFile(dataFile);

bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("==============================================");
    Console.WriteLine("🎯 CHƯƠNG TRÌNH QUẢN LÝ SINH VIÊN (.NET 8)");
    Console.WriteLine("==============================================");
    Console.WriteLine("1. Thêm sinh viên mới");
    Console.WriteLine("2. Cập nhật thông tin sinh viên");
    Console.WriteLine("3. Xóa sinh viên");
    Console.WriteLine("4. Tìm kiếm sinh viên theo tên");
    Console.WriteLine("5. Sắp xếp danh sách (theo GPA)");
    Console.WriteLine("6. Sắp xếp danh sách (theo Tên)");
    Console.WriteLine("7. Hiển thị tất cả sinh viên");
    Console.WriteLine("0. Lưu và Thoát");
    Console.WriteLine("==============================================");
    Console.Write("Chọn chức năng (0-7): ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1": AddNewStudent(); break;
        case "2": UpdateStudent(); break;
        case "3": DeleteStudent(); break;
        case "4": SearchStudent(); break;
        case "5": ShowAllSorted(manager.SortByGPA(), "GPA GIẢM DẦN"); break;
        case "6": ShowAllSorted(manager.SortByName(), "TÊN A-Z"); break;
        case "7": ShowAll(); break;
        case "0": 
            manager.SaveToFile(dataFile);
            Console.WriteLine("✅ Đã lưu dữ liệu. Tạm biệt!");
            running = false; 
            break;
        default: 
            Console.WriteLine("❌ Lựa chọn không hợp lệ!"); 
            Pause();
            break;
    }
}

void AddNewStudent()
{
    Console.WriteLine("\n--- THÊM SINH VIÊN MỚI ---");
    int id = GetInputInt("Nhập ID: ");
    
    if (manager.GetStudentById(id) != null)
    {
        Console.WriteLine("❌ ID này đã tồn tại!");
        Pause();
        return;
    }

    Console.Write("Nhập Tên: ");
    string name = Console.ReadLine() ?? "Unknown";

    int age = GetInputInt("Nhập Tuổi: ");
    
    Console.WriteLine("Giới tính: 0-Nam, 1-Nữ, 2-Khác");
    int genderVal = GetInputInt("Chọn giới tính: ");
    Gender gender = (Gender)(genderVal >= 0 && genderVal <= 2 ? genderVal : 2);

    double gpa = GetInputDouble("Nhập GPA (0-10): ");

    manager.AddStudent(new Student(id, name, age, gender, gpa));
    Console.WriteLine("✅ Thêm thành công!");
    Pause();
}

void UpdateStudent()
{
    Console.WriteLine("\n--- CẬP NHẬT SINH VIÊN ---");
    int id = GetInputInt("Nhập ID sinh viên cần sửa: ");
    var existing = manager.GetStudentById(id);

    if (existing == null)
    {
        Console.WriteLine("❌ Không tìm thấy sinh viên!");
        Pause();
        return;
    }

    Console.WriteLine($"Đang sửa: {existing}");
    Console.Write("Họ tên mới (để trống nếu giữ nguyên): ");
    string nameInput = Console.ReadLine() ?? "";
    string name = string.IsNullOrEmpty(nameInput) ? existing.Name : nameInput;

    Console.Write("Tuổi mới (Enter để giữ nguyên): ");
    string ageInput = Console.ReadLine() ?? "";
    int age = string.IsNullOrEmpty(ageInput) ? existing.Age : int.Parse(ageInput);

    Console.Write("GPA mới (Enter để giữ nguyên): ");
    string gpaInput = Console.ReadLine() ?? "";
    double gpa = string.IsNullOrEmpty(gpaInput) ? existing.GPA : double.Parse(gpaInput);

    manager.UpdateStudent(id, new Student(id, name, age, existing.Gender, gpa));
    Console.WriteLine("✅ Cập nhật thành công!");
    Pause();
}

void DeleteStudent()
{
    Console.WriteLine("\n--- XÓA SINH VIÊN ---");
    int id = GetInputInt("Nhập ID cần xóa: ");
    if (manager.DeleteStudent(id))
        Console.WriteLine("✅ Đã xóa!");
    else
        Console.WriteLine("❌ Không tìm thấy ID!");
    Pause();
}

void SearchStudent()
{
    Console.Write("\nNhập tên cần tìm: ");
    string name = Console.ReadLine() ?? "";
    var results = manager.SearchByName(name);
    ShowList(results, $"KẾT QUẢ TÌM KIẾM CHO '{name}'");
}

void ShowAll()
{
    ShowList(manager.GetAllStudents(), "DANH SÁCH TẤT CẢ SINH VIÊN");
}

void ShowAllSorted(IEnumerable<Student> list, string title)
{
    ShowList(list, $"DANH SÁCH SINH VIÊN ({title})");
}

void ShowList(IEnumerable<Student> list, string title)
{
    Console.WriteLine($"\n--- {title} ---");
    if (!list.Any())
    {
        Console.WriteLine(" (Danh sách trống) ");
    }
    else
    {
        foreach (var s in list)
            Console.WriteLine(s);
    }
    Pause();
}

// Helpers
int GetInputInt(string message)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int res)) return res;
        Console.WriteLine("❌ Lỗi: Vui lòng nhập số!");
    }
}

double GetInputDouble(string message)
{
    while (true)
    {
        Console.Write(message);
        if (double.TryParse(Console.ReadLine(), out double res)) return res;
        Console.WriteLine("❌ Lỗi: Vui lòng nhập số thực!");
    }
}

void Pause()
{
    Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
    Console.ReadKey();
}
