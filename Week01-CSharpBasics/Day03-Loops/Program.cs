// ============================================
// 📅 NGÀY 3: LOOPS - FOR, WHILE, FOREACH
// ============================================
// Mục tiêu: Ôn lại các vòng lặp trong C#
// Thời gian: 28/01/2026

Console.WriteLine("=== NGÀY 3: LOOPS ===\n");

// ============================================
// 1️⃣ FOR LOOP - Biết trước số lần lặp
// ============================================
Console.WriteLine("--- 1. For Loop ---");

// Cú pháp: for (khởi_tạo; điều_kiện; tăng/giảm)
for (int i = 1; i <= 5; i++)
{
    Console.WriteLine($"Lần lặp thứ {i}");
}

// In bảng cửu chương 5
Console.WriteLine("\nBảng cửu chương 5:");
for (int i = 1; i <= 10; i++)
{
    Console.WriteLine($"5 x {i} = {5 * i}");
}

// ============================================
// 2️⃣ WHILE LOOP - Lặp khi điều kiện còn đúng
// ============================================
Console.WriteLine("\n--- 2. While Loop ---");

// Cú pháp: while (điều_kiện) { }
int dem = 1;
while (dem <= 3)
{
    Console.WriteLine($"While - Đếm: {dem}");
    dem++;  // QUAN TRỌNG: phải tăng/giảm để tránh vòng lặp vô hạn!
}

// Ví dụ: Đếm ngược
Console.WriteLine("\nĐếm ngược:");
int countdown = 5;
while (countdown > 0)
{
    Console.WriteLine(countdown);
    countdown--;
}
Console.WriteLine("🚀 Phóng!");

// ============================================
// 3️⃣ DO-WHILE LOOP - Chạy ít nhất 1 lần
// ============================================
Console.WriteLine("\n--- 3. Do-While Loop ---");

// Khác với while: kiểm tra điều kiện SAU khi chạy
int soLan = 0;
do
{
    Console.WriteLine($"Do-While chạy lần {soLan + 1}");
    soLan++;
} while (soLan < 3);

// Ví dụ thực tế: Menu cho đến khi chọn thoát
// (Comment vì sẽ chờ input)
/*
string luaChon;
do
{
    Console.WriteLine("1. Xem danh sách");
    Console.WriteLine("2. Thêm mới");
    Console.WriteLine("0. Thoát");
    luaChon = Console.ReadLine();
} while (luaChon != "0");
*/

// ============================================
// 4️⃣ FOREACH LOOP - Duyệt qua collection
// ============================================
Console.WriteLine("\n--- 4. Foreach Loop ---");

// Duyệt mảng
string[] monHoc = { "C#", "SQL", "ASP.NET", "Entity Framework" };

Console.WriteLine("Các môn cần học:");
foreach (string mon in monHoc)
{
    Console.WriteLine($"  📚 {mon}");
}

// Duyệt List
List<int> danhSachDiem = new List<int> { 8, 9, 7, 10, 6 };

Console.WriteLine("\nDanh sách điểm:");
foreach (int d in danhSachDiem)
{
    Console.Write($"{d} ");
}
Console.WriteLine();

// ============================================
// 5️⃣ BREAK & CONTINUE
// ============================================
Console.WriteLine("\n--- 5. Break & Continue ---");

// BREAK - Thoát khỏi vòng lặp ngay lập tức
Console.WriteLine("Break - Tìm số 5:");
for (int i = 1; i <= 10; i++)
{
    if (i == 5)
    {
        Console.WriteLine($"Tìm thấy {i}! Dừng lại.");
        break;  // Thoát vòng lặp
    }
    Console.WriteLine($"Đang tìm... {i}");
}

// CONTINUE - Bỏ qua lần lặp hiện tại, sang lần tiếp theo
Console.WriteLine("\nContinue - In số lẻ từ 1-10:");
for (int i = 1; i <= 10; i++)
{
    if (i % 2 == 0)
    {
        continue;  // Bỏ qua số chẵn
    }
    Console.Write($"{i} ");
}
Console.WriteLine();

// ============================================
// 6️⃣ NESTED LOOPS - Vòng lặp lồng nhau
// ============================================
Console.WriteLine("\n--- 6. Nested Loops ---");

// In hình chữ nhật bằng *
Console.WriteLine("Hình chữ nhật 3x5:");
for (int dong = 1; dong <= 3; dong++)
{
    for (int cot = 1; cot <= 5; cot++)
    {
        Console.Write("* ");
    }
    Console.WriteLine();  // Xuống dòng sau mỗi hàng
}

// In tam giác vuông
Console.WriteLine("\nTam giác vuông:");
for (int i = 1; i <= 5; i++)
{
    for (int j = 1; j <= i; j++)
    {
        Console.Write("* ");
    }
    Console.WriteLine();
}

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP THỰC HÀNH ===");

// BÀI 1: Tính tổng từ 1 đến N
Console.WriteLine("\n--- Bài 1: Tính tổng 1 đến N ---");
Console.Write("Nhập N: ");
int n = int.Parse(Console.ReadLine() ?? "10");
int tong = 0;
for (int i = 1; i <= n; i++)
{
    tong += i;
}
Console.WriteLine($"Tổng từ 1 đến {n} = {tong}");

// TODO: BÀI 2 - Tự làm
// Tìm tất cả số nguyên tố từ 1 đến N
Console.Write("Nhập N: ");
int number = int.Parse(Console.ReadLine() ?? "10");

Console.WriteLine($"Các số nguyên tố từ 1 đến {number}:");
for (int num = 2; num <= number; num++)  // Duyệt từng số từ 2 đến N
{
    bool laSoNguyenTo = true;  // Giả sử là số nguyên tố
    
    for (int i = 2; i < num; i++)  // Kiểm tra chia hết từ 2 đến num-1
    {
        if (num % i == 0)
        {
            laSoNguyenTo = false;  // Chia hết → không phải số nguyên tố
            break;
        }
    }
    
    if (laSoNguyenTo)
    {
        Console.Write($"{num} ");
    }
}

// TODO: BÀI 3 - Tự làm
// Đảo ngược một số (VD: 123 → 321)
Console.Write("Nhập số: ");
int number1 = int.Parse(Console.ReadLine() ?? "123");
int numberGoc = number1;  // ← Lưu lại giá trị gốc!
int reverse = 0;
while (number1 > 0)
{
    reverse = reverse * 10 + number1 % 10;
    number1 /= 10;
}
Console.WriteLine($"Đảo ngược của {numberGoc} là {reverse}");