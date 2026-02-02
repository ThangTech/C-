// ============================================
// 📅 NGÀY 10: LINQ - Language Integrated Query
// ============================================
// Mục tiêu: Thao tác với Collections bằng LINQ
// Thời gian: 02/02/2026
// LINQ = Siêu năng lực khi làm việc với data!

Console.WriteLine("=== NGÀY 10: LINQ ===\n");

// Sample data
List<Student> students = new()
{
    new Student(1, "An", 20, 8.5),
    new Student(2, "Bình", 22, 7.0),
    new Student(3, "Cường", 21, 9.0),
    new Student(4, "Dũng", 20, 6.5),
    new Student(5, "Hoa", 23, 8.0),
    new Student(6, "Khánh", 21, 9.5),
};

// ============================================
// 1️⃣ WHERE - Lọc dữ liệu
// ============================================
Console.WriteLine("--- 1. Where (Lọc) ---");

// Lọc sinh viên có điểm >= 8
var gioi = students.Where(s => s.Diem >= 8);
Console.WriteLine("SV Giỏi (điểm >= 8):");
foreach (var s in gioi)
    Console.WriteLine($"  - {s.Name}: {s.Diem}");

// ============================================
// 2️⃣ SELECT - Chọn/Biến đổi dữ liệu
// ============================================
Console.WriteLine("\n--- 2. Select (Chọn) ---");

// Lấy chỉ tên sinh viên
var names = students.Select(s => s.Name);
Console.WriteLine("Danh sách tên: " + string.Join(", ", names));

// Chuyển đổi sang object mới (Anonymous Type)
var info = students.Select(s => new { s.Name, XepLoai = s.Diem >= 8 ? "Giỏi" : "Khá" });
foreach (var i in info)
    Console.WriteLine($"  {i.Name}: {i.XepLoai}");

// ============================================
// 3️⃣ ORDERBY - Sắp xếp
// ============================================
Console.WriteLine("\n--- 3. OrderBy (Sắp xếp) ---");

var sortedByDiem = students.OrderByDescending(s => s.Diem);
Console.WriteLine("Xếp theo điểm giảm dần:");
foreach (var s in sortedByDiem)
    Console.WriteLine($"  {s.Name}: {s.Diem}");

// ============================================
// 4️⃣ FIRST, LAST, SINGLE
// ============================================
Console.WriteLine("\n--- 4. First, Last, Single ---");

var first = students.First();                    // Phần tử đầu
var firstGioi = students.First(s => s.Diem >= 9); // Đầu tiên thỏa điều kiện
var last = students.Last();                      // Cuối cùng

Console.WriteLine($"First: {first.Name}");
Console.WriteLine($"First Giỏi: {firstGioi.Name}");

// FirstOrDefault - Trả về null nếu không tìm thấy (an toàn hơn)
var notFound = students.FirstOrDefault(s => s.Diem > 10);
Console.WriteLine($"Điểm > 10: {notFound?.Name ?? "Không có"}");

// ============================================
// 5️⃣ ANY, ALL, COUNT
// ============================================
Console.WriteLine("\n--- 5. Any, All, Count ---");

bool coSVGioi = students.Any(s => s.Diem >= 9);     // Có ít nhất 1?
bool tatCaDat = students.All(s => s.Diem >= 5);     // Tất cả thỏa?
int soLuongGioi = students.Count(s => s.Diem >= 8); // Đếm

Console.WriteLine($"Có SV giỏi (>=9)? {coSVGioi}");
Console.WriteLine($"Tất cả đạt (>=5)? {tatCaDat}");
Console.WriteLine($"Số SV giỏi (>=8): {soLuongGioi}");

// ============================================
// 6️⃣ SUM, AVERAGE, MIN, MAX
// ============================================
Console.WriteLine("\n--- 6. Sum, Average, Min, Max ---");

double tongDiem = students.Sum(s => s.Diem);
double diemTB = students.Average(s => s.Diem);
double diemMax = students.Max(s => s.Diem);
double diemMin = students.Min(s => s.Diem);

Console.WriteLine($"Tổng điểm: {tongDiem}");
Console.WriteLine($"Điểm TB: {diemTB:F2}");
Console.WriteLine($"Điểm cao nhất: {diemMax}");
Console.WriteLine($"Điểm thấp nhất: {diemMin}");

// ============================================
// 7️⃣ CHAIN METHODS (Nối nhiều phép)
// ============================================
Console.WriteLine("\n--- 7. Chain Methods ---");

// Lọc SV >= 8 điểm, sắp xếp theo tên, lấy tên
var result = students
    .Where(s => s.Diem >= 8)
    .OrderBy(s => s.Name)
    .Select(s => s.Name);

Console.WriteLine("SV Giỏi (theo ABC): " + string.Join(", ", result));

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");

// Bài 1: Lọc SV tuổi 21, sắp xếp theo điểm giảm dần
Console.WriteLine("\n--- Bài 1: SV 21 tuổi, xếp theo điểm (TỰ LÀM) ---");
var bai1 = students
       .Where(s => s.Age == 21)
       .OrderByDescending(s => s.Diem);
Console.WriteLine(string.Join(", ", bai1.Select(s => s.Name)));

// Bài 2: Tìm SV có điểm cao nhất
Console.WriteLine("\n--- Bài 2: SV điểm cao nhất (TỰ LÀM) ---");
var bai2 = students
       .OrderByDescending(s => s.Diem)
       .First();
Console.WriteLine($"Top 1: {bai2.Name} - {bai2.Diem}");


// ============================================
// 👇 CLASS STUDENT
// ============================================
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public double Diem { get; set; }

    public Student(int id, string name, int age, double diem)
    {
        Id = id;
        Name = name;
        Age = age;
        Diem = diem;
    }
}
