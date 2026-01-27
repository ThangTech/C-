// ============================================
// 📅 NGÀY 2: CONTROL FLOW - IF/ELSE, SWITCH
// ============================================
// Mục tiêu: Ôn lại cấu trúc điều khiển trong C#
// Thời gian: 27/01/2026

Console.WriteLine("=== NGÀY 2: CONTROL FLOW ===\n");

// ============================================
// 1️⃣ IF - ELSE CƠ BẢN
// ============================================
Console.WriteLine("--- 1. If-Else cơ bản ---");

int diem = 75;

if (diem >= 90)
{
    Console.WriteLine("Xuất sắc! 🌟");
}
else if (diem >= 80)
{
    Console.WriteLine("Giỏi! 👍");
}
else if (diem >= 70)
{
    Console.WriteLine("Khá! 👌");
}
else if (diem >= 50)
{
    Console.WriteLine("Trung bình");
}
else
{
    Console.WriteLine("Yếu - Cần cố gắng hơn!");
}

// ============================================
// 2️⃣ TOÁN TỬ SO SÁNH
// ============================================
Console.WriteLine("\n--- 2. Toán tử so sánh ---");

int a = 10, b = 20;

Console.WriteLine($"a = {a}, b = {b}");
Console.WriteLine($"a == b: {a == b}");  // Bằng
Console.WriteLine($"a != b: {a != b}");  // Khác
Console.WriteLine($"a > b: {a > b}");    // Lớn hơn
Console.WriteLine($"a < b: {a < b}");    // Nhỏ hơn
Console.WriteLine($"a >= b: {a >= b}");  // Lớn hơn hoặc bằng
Console.WriteLine($"a <= b: {a <= b}");  // Nhỏ hơn hoặc bằng

// ============================================
// 3️⃣ TOÁN TỬ LOGIC
// ============================================
Console.WriteLine("\n--- 3. Toán tử logic ---");

int tuoi = 20;
bool coThe = true;

// AND (&&) - Cả hai điều kiện đều phải đúng
if (tuoi >= 18 && coThe)
{
    Console.WriteLine("Bạn đủ điều kiện lái xe! 🚗");
}

// OR (||) - Chỉ cần một điều kiện đúng
bool laSinhVien = true;
bool laNguoiGia = false;

if (laSinhVien || laNguoiGia)
{
    Console.WriteLine("Bạn được giảm giá vé! 🎫");
}

// NOT (!) - Đảo ngược
bool troi_mua = false;
if (!troi_mua)
{
    Console.WriteLine("Trời không mưa, đi chơi thôi! ☀️");
}

// ============================================
// 4️⃣ TERNARY OPERATOR (Toán tử 3 ngôi)
// ============================================
Console.WriteLine("\n--- 4. Ternary Operator ---");

int soA1 = 15;
// Cú pháp: điều_kiện ? giá_trị_nếu_đúng : giá_trị_nếu_sai
string ketQua = soA1 % 2 == 0 ? "Số chẵn" : "Số lẻ";
Console.WriteLine($"{soA1} là {ketQua}");

// So sánh với if-else thông thường:
// if (soA % 2 == 0)
//     ketQua = "Số chẵn";
// else
//     ketQua = "Số lẻ";

// ============================================
// 5️⃣ SWITCH STATEMENT
// ============================================
Console.WriteLine("\n--- 5. Switch Statement ---");

int thang = 1;

switch (thang)
{
    case 1:
        Console.WriteLine("Tháng Một - Tết đến rồi! 🧧");
        break;
    case 2:
        Console.WriteLine("Tháng Hai - Valentine! 💕");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Mùa xuân! 🌸");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("Mùa hè - Nghỉ hè! ☀️");
        break;
    default:
        Console.WriteLine("Các tháng còn lại");
        break;
}

// ============================================
// 6️⃣ SWITCH EXPRESSION (C# 8+) - HIỆN ĐẠI
// ============================================
Console.WriteLine("\n--- 6. Switch Expression (C# 8+) ---");

string ngay = "Monday";

string loaiNgay = ngay switch
{
    "Saturday" or "Sunday" => "Cuối tuần! 🎉",
    "Friday" => "Chuẩn bị cuối tuần! 🙌",
    _ => "Ngày thường 😅"  // _ là default
};

Console.WriteLine($"{ngay}: {loaiNgay}");

// Với số:
int diemSo = 85;
string xepLoai = diemSo switch
{
    >= 90 => "A",
    >= 80 => "B", 
    >= 70 => "C",
    >= 60 => "D",
    _ => "F"
};
Console.WriteLine($"Điểm {diemSo} → Xếp loại {xepLoai}");

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP THỰC HÀNH ===");

// BÀI 1: Máy tính đơn giản
Console.WriteLine("\n--- Bài 1: Máy tính đơn giản ---");
Console.Write("Nhập số thứ nhất: ");
double so1 = double.Parse(Console.ReadLine() ?? "0");
Console.Write("Nhập số thứ hai: ");
double so2 = double.Parse(Console.ReadLine() ?? "0");
Console.Write("Nhập phép tính (+, -, *, /): ");
string phepTinh = Console.ReadLine() ?? "+";

double ketQuaTinh = phepTinh switch
{
    "+" => so1 + so2,
    "-" => so1 - so2,
    "*" => so1 * so2,
    "/" => so2 != 0 ? so1 / so2 : 0,
    _ => 0
};

Console.WriteLine($"Kết quả: {so1} {phepTinh} {so2} = {ketQuaTinh}");

// TODO: BÀI 2 - Tự làm
// Viết chương trình kiểm tra năm nhuận
// Năm nhuận: chia hết cho 4 VÀ (không chia hết cho 100 HOẶC chia hết cho 400)
Console.WriteLine("\n--- Bài 2: Kiểm tra năm nhuận (TỰ LÀM) ---");
// Code của bạn ở đây...
Console.Write("Nhập năm: ");
int nam = int.Parse(Console.ReadLine() ?? "0");
if (nam % 4 == 0 && (nam % 100 != 0 || nam % 400 == 0))
{
    Console.WriteLine($"{nam} là năm nhuận");
}
else
{
    Console.WriteLine($"{nam} không phải là năm nhuận");
}

// TODO: BÀI 3 - Tự làm  
// Nhập 3 số, in ra số lớn nhất
Console.WriteLine("\n--- Bài 3: Tìm số lớn nhất (TỰ LÀM) ---");
// Code của bạn ở đây...
Console.Write("Nhập số thứ nhất: ");
int soA = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Nhập số thứ hai: ");
int soB = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Nhập số thứ ba: ");
int soC = int.Parse(Console.ReadLine() ?? "0");
int soLonNhat = soA;
if (soB > soLonNhat)
{
    soLonNhat = soB;
}
if (soC > soLonNhat)
{
    soLonNhat = soC;
}
Console.WriteLine($"Số lớn nhất là: {soLonNhat}");

