// ============================================
// 📅 NGÀY 5: METHODS (HÀM)
// ============================================

// 👇 KHAI BÁO CÁC HÀM Ở ĐÂY (LOCAL FUNCTIONS)
// ---------------------------------------------------------

// --- HÀM DEMO ---
void SayHello() => Console.WriteLine("Hello World!");

void SayHelloTo(string name) => Console.WriteLine($"Hello {name}!");

int Add(int a, int b) => a + b;

bool IsEvenNumber(int n) => n % 2 == 0;

void DoubleValue(ref int n) => n = n * 2;

void GetDivisionInfo(int dividend, int divisor, out int result, out int remainder)
{
    result = dividend / divisor;
    remainder = dividend % divisor;
}

void PrintInfo(string productName, double price = 0)
{
    Console.WriteLine($"Sản phẩm: {productName}, Giá: {price:N0}");
}

// --- HÀM BÀI TẬP (GIẢI) ---

// Bài 1: Tính giai thừa
long CalculateFactorial(int n)
{
    if (n < 0) return 0; // Không tính số âm
    if (n == 0 || n == 1) return 1;
    
    long result = 1;
    for (int i = 2; i <= n; i++)
    {
        result *= i;
    }
    return result;
}

// Bài 2: Giải PT bậc 1 (ax + b = 0)
void SolveLinearEquation(double a, double b)
{
    Console.Write($"Giải PT {a}x + {b} = 0: ");
    if (a == 0)
    {
        if (b == 0) Console.WriteLine("Vô số nghiệm");
        else Console.WriteLine("Vô nghiệm");
    }
    else
    {
        double x = -b / a;
        Console.WriteLine($"x = {x}");
    }
}

// Bài 3: Nhập số an toàn (Bắt nhập lại nếu sai)
int GetValidNumber(string message)
{
    int result;
    while (true)
    {
        Console.Write(message); // VD: "Nhập tuổi: "
        string? input = Console.ReadLine();
        
        // int.TryParse trả về true nếu parse thành công, false nếu thất bại
        // result sẽ chứa giá trị sau khi parse (nhờ out)
        if (int.TryParse(input, out result))
        {
            return result; // Nhập đúng -> thoát vòng lặp, trả về kết quả
        }
        
        Console.WriteLine("❌ Lỗi: Vui lòng nhập số nguyên hợp lệ!");
    }
}

// ============================================
// 👇 CODE CHÍNH CHẠY Ở ĐÂY
// ============================================
Console.WriteLine("=== NGÀY 5: METHODS (HÀM) ===\n");

// 1. Demo cơ bản
Console.WriteLine("--- 1. Demo Methods ---");
SayHelloTo("Minh");
int sum = Add(10, 20);
Console.WriteLine($"Tổng: {sum}, Chẵn? {IsEvenNumber(sum)}");

// 2. Demo Ref/Out
Console.WriteLine("\n--- 2. Demo Ref & Out ---");
int val = 5;
DoubleValue(ref val);
Console.WriteLine($"Double(5) = {val}");

int x = 17, y = 5;
GetDivisionInfo(x, y, out int thuong, out int du);
Console.WriteLine($"{x} / {y} = {thuong} dư {du}");

// 3. Demo Optional Params
Console.WriteLine("\n--- 3. Demo Optional Params ---");
PrintInfo("IPhone 15");

// ============================================
// 🎯 CHẠY BÀI TẬP ĐÃ GIẢI
// ============================================
Console.WriteLine("\n=== RUN BÀI TẬP ===");

// Bài 1
Console.WriteLine("\n--- Bài 1: Giai thừa ---");
int n = 5;
Console.WriteLine($"{n}! = {CalculateFactorial(n)}");
Console.WriteLine($"6! = {CalculateFactorial(6)}");

// Bài 2
Console.WriteLine("\n--- Bài 2: Giải PT Bậc 1 ---");
SolveLinearEquation(2, -4);  // 2x - 4 = 0 -> x = 2
SolveLinearEquation(0, 5);   // 0x + 5 = 0 -> Vô nghiệm
SolveLinearEquation(0, 0);   // 0x + 0 = 0 -> Vô số nghiệm

// Bài 3
Console.WriteLine("\n--- Bài 3: Nhập số an toàn ---");
// Gọi hàm nhập số để lấy tuổi
int tuoi = GetValidNumber("Nhập tuổi của bạn: ");
Console.WriteLine($"-> Tuổi đã nhập: {tuoi}");

// Gọi hàm nhập số để lấy năm sinh
int namSinh = GetValidNumber("Nhập năm sinh: ");
Console.WriteLine($"-> Năm sinh đã nhập: {namSinh}");
