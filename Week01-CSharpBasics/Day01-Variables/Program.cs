// ============================================
// 📅 NGÀY 1: VARIABLES & DATA TYPES
// ============================================
// Mục tiêu: Ôn lại các kiểu dữ liệu cơ bản trong C#
// Thời gian: 26/01/2026

Console.WriteLine("=== NGÀY 1: VARIABLES & DATA TYPES ===\n");

// ============================================
// 1️⃣ KIỂU SỐ NGUYÊN (Integer Types)
// ============================================ 
Console.WriteLine("--- 1. Kiểu số nguyên ---");

int tuoi = 21;                    // Phổ biến nhất, -2.1 tỷ đến 2.1 tỷ
long danSoVietNam = 100_000_000;  // Số lớn hơn, dùng _ để dễ đọc
short soNho = 32000;              // Số nhỏ, tiết kiệm bộ nhớ
byte tuoiMax = 255;               // 0 đến 255

Console.WriteLine($"Tuổi: {tuoi}");
Console.WriteLine($"Dân số VN: {danSoVietNam:N0}"); // N0 = format có dấu phẩy

// ============================================
// 2️⃣ KIỂU SỐ THỰC (Floating-Point Types)
// ============================================
Console.WriteLine("\n--- 2. Kiểu số thực ---");

float diemTB = 8.5f;              // Cần thêm 'f' ở cuối
double pi = 3.14159265359;        // Chính xác hơn float
decimal tienLuong = 15_000_000m;  // Dùng cho tiền, cần 'm' ở cuối

Console.WriteLine($"Điểm TB: {diemTB}");
Console.WriteLine($"Pi: {pi}");
Console.WriteLine($"Lương: {tienLuong:C0}"); // C0 = format tiền tệ

// ============================================
// 3️⃣ KIỂU VĂN BẢN & KÝ TỰ (String & Char)
// ============================================
Console.WriteLine("\n--- 3. Kiểu văn bản ---");

string hoTen = "Nguyễn Văn A";
char gioiTinh = 'M';              // Chỉ 1 ký tự, dùng nháy đơn

Console.WriteLine($"Họ tên: {hoTen}");
Console.WriteLine($"Giới tính: {gioiTinh}");

// String interpolation - cách nối chuỗi hiện đại
string gioiThieu = $"Tôi là {hoTen}, {tuoi} tuổi";
Console.WriteLine(gioiThieu);

// ============================================
// 4️⃣ KIỂU BOOLEAN (True/False)
// ============================================
Console.WriteLine("\n--- 4. Kiểu boolean ---");

bool laSinhVien = true;
bool daTotNghiep = false;

Console.WriteLine($"Là sinh viên: {laSinhVien}");
Console.WriteLine($"Đã tốt nghiệp: {daTotNghiep}");

// ============================================
// 5️⃣ VAR & CONST
// ============================================
Console.WriteLine("\n--- 5. var và const ---");

var tenTruong = "Đại học ABC";    // Compiler tự suy ra kiểu string
const double PI = 3.14159;        // Hằng số, không thể thay đổi

Console.WriteLine($"Trường: {tenTruong}");
Console.WriteLine($"Hằng số PI: {PI}");

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP THỰC HÀNH ===");
Console.WriteLine("Hãy tự viết code cho các bài sau:");
Console.WriteLine("1. Tính tuổi từ năm sinh (nhập năm sinh từ bàn phím)");
Console.WriteLine("2. Nhập tên, tuổi và in ra lời chào");
Console.WriteLine("3. Tính tổng tiền = đơn giá * số lượng");

// TODO: Viết code bài tập ở đây
// Gợi ý: Console.ReadLine() để nhập, int.Parse() để chuyển sang số

Console.WriteLine("\n--- Bài 1: Tính tuổi ---");
Console.Write("Nhập năm sinh của bạn: ");
string? input = Console.ReadLine();
int namSinh = int.Parse(input ?? "2000");
int tuoiHienTai = 2026 - namSinh;
Console.WriteLine($"Năm nay bạn {tuoiHienTai} tuổi!");

Console.WriteLine("\n--- Bài 2: Lời chào ---");
Console.Write("Nhập tên của bạn: ");
string name = Console.ReadLine();
Console.Write("Nhập tuổi của bạn: ");
int age = int.Parse(Console.ReadLine());
Console.WriteLine($"Xin chào {name}, bạn {age} tuổi");

Console.WriteLine("\n--- Bài 3: Tính tổng tiền ---");
Console.Write("Nhập đơn giá: ");
decimal donGia = decimal.Parse(Console.ReadLine());
Console.Write("Nhập số lượng: ");
int soLuong = int.Parse(Console.ReadLine());
Console.WriteLine($"Tổng tiền: {donGia * soLuong}");
