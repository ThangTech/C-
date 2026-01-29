// ============================================
// 📅 NGÀY 4: ARRAYS & COLLECTIONS
// ============================================
// Mục tiêu: Làm việc với mảng và danh sách trong C#
// Thời gian: 29/01/2026

Console.WriteLine("=== NGÀY 4: ARRAYS & COLLECTIONS ===\n");

// ============================================
// 1️⃣ ARRAYS (Mảng) - Kích thước cố định
// ============================================
Console.WriteLine("--- 1. Arrays ---");

// Khai báo mảng số nguyên 5 phần tử
int[] numbers = new int[5]; // Mặc định là {0, 0, 0, 0, 0} 
numbers[0] = 10; 
numbers[1] = 20;

// Khai báo và khởi tạo giá trị
string[] fruits = { "Apple",  "Banana", "Orange", "Mango" };

Console.WriteLine($"Số phần tử: {fruits.Length}");
Console.WriteLine($"Phần tử thứ 2: {fruits[1]}"); // Index bắt đầu từ 0

// Duyệt mảng bằng for
Console.WriteLine("\nDuyệt mảng (for):");
for (int i = 0; i < fruits.Length; i++)
{
    Console.WriteLine($"- {fruits[i]}");
} 

// ============================================
// 2️⃣ LIST<T> (Danh sách) - Kích thước động
// ============================================
Console.WriteLine("\n--- 2. List<T> ---");

// Cần: using System.Collections.Generic; (mặc định đã có trong .NET mới)
List<string> students = new List<string>();

// Thêm phần tử
students.Add("An");
students.Add("Bình");
students.Add("Cường");
students.AddRange(new[] { "Dũng", "Hoa" }); // Thêm nhiều

// Chèn vào vị trí cụ thể
students.Insert(1, "Bảo"); // Chèn vào vị trí 1

// Xóa
students.Remove("Cường"); // Xóa theo giá trị
students.RemoveAt(0);     // Xóa phần tử đầu tiên

Console.WriteLine($"Số sinh viên: {students.Count}");

// Duyệt List bằng foreach (thường dùng nhất)
Console.WriteLine("Danh sách SV:");
foreach (var sv in students)
{
    Console.WriteLine($"🎓 {sv}");
}

// Kiểm tra tồn tại
bool coHoa = students.Contains("Hoa");
Console.WriteLine($"Có Hoa không? {coHoa}");

// ============================================
// 3️⃣ DICTIONARY<TKey, TValue> (Từ điển)
// ============================================
Console.WriteLine("\n--- 3. Dictionary ---");

// Lưu cặp Key-Value (Key là duy nhất)
Dictionary<string, string> countries = new Dictionary<string, string>();
countries.Add("VN", "Vietnam");
countries.Add("US", "United States");
countries.Add("JP", "Japan");

// Truy cập bằng Key
Console.WriteLine($"VN là: {countries["VN"]}");

// Kiểm tra Key trước khi truy cập để tránh lỗi
if (countries.ContainsKey("UK"))
{
    Console.WriteLine(countries["UK"]);
}
else
{
    Console.WriteLine("Không tìm thấy UK");
}

// Duyệt Dictionary
foreach (var pair in countries)
{
    Console.WriteLine($"{pair.Key}: {pair.Value}");
}

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP THỰC HÀNH ===");

// BÀI 1: Quản lý điểm số (List)
// Tạo List điểm số, nhập vào, tính trung bình
Console.WriteLine("\n--- Bài 1: Quản lý điểm (Demo) ---");
List<double> scores = new List<double> { 8.5, 9.0, 7.5, 6.0, 10.0 };
double sum = 0;
foreach (var s in scores)
{
    sum += s;
}
Console.WriteLine($"Điểm trung bình: {sum / scores.Count}");

// TODO: BÀI 2 - Tự làm
// Tìm số lớn nhất và nhỏ nhất trong mảng (Không dùng LINQ .Max() .Min())
Console.WriteLine("\n--- Bài 2: Min/Max trong mảng (TỰ LÀM) ---");
int[] myNumbers = { 10, 5, 20, 8, 15, 30, 2 };
// Code của bạn ở đây...
int max = myNumbers[0];
int min = myNumbers[0];

for (int i = 1; i < myNumbers.Length; i++){
       if(myNumbers[i] > max)
       {
         max = myNumbers[i];
       }
       if(myNumbers[i] < min)
       {
         min = myNumbers[i];
       }
}
Console.WriteLine($"Max: {max}");
Console.WriteLine($"Min: {min}");

// TODO: BÀI 3 - Tự làm
// Nhập danh sách tên món ăn vào List cho đến khi nhập "xong". In ra danh sách.
Console.WriteLine("\n--- Bài 3: Danh sách món ăn (TỰ LÀM) ---");
// Code của bạn ở đây...
List<string> food = new List<string>();
string input;
do{
       Console.WriteLine("Nhập tên món ăn:");
       input = Console.ReadLine() ?? "";
       if(input != "xong"){
              food.Add(input);
       }
}while(input != "xong");
Console.WriteLine("Danh sách món ăn:");
foreach(var f in food)
{
       Console.WriteLine($"- {f}");
}
