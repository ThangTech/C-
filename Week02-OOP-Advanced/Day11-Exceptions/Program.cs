// ============================================
// 📅 NGÀY 11: EXCEPTION HANDLING
// ============================================
// Mục tiêu: Xử lý lỗi chuyên nghiệp với try-catch-finally
// Thời gian: 03/02/2026

Console.WriteLine("=== NGÀY 11: EXCEPTION HANDLING ===\n");

// ============================================
// 1️⃣ TRY-CATCH CƠ BẢN
// ============================================
Console.WriteLine("--- 1. Try-Catch Cơ Bản ---");

try
{
    Console.Write("Nhập một số: ");
    int number = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine($"Bạn nhập: {number}");
}
catch (FormatException ex)
{
    Console.WriteLine($"❌ Lỗi: Bạn phải nhập số! ({ex.Message})");
}

// ============================================
// 2️⃣ NHIỀU CATCH BLOCKS
// ============================================
Console.WriteLine("\n--- 2. Nhiều Catch Blocks ---");

try
{
    int[] arr = { 1, 2, 3 };
    Console.Write("Nhập index (0-2): ");
    int index = int.Parse(Console.ReadLine() ?? "0");
    Console.WriteLine($"Giá trị: {arr[index]}");
}
catch (FormatException)
{
    Console.WriteLine("❌ Lỗi format: Phải nhập số!");
}
catch (IndexOutOfRangeException)
{
    Console.WriteLine("❌ Lỗi index: Index phải từ 0-2!");
}
catch (Exception ex)  // Catch tổng quát - Luôn đặt cuối cùng
{
    Console.WriteLine($"❌ Lỗi khác: {ex.Message}");
}

// ============================================
// 3️⃣ FINALLY - Luôn chạy dù có lỗi hay không
// ============================================
Console.WriteLine("\n--- 3. Finally Block ---");

try
{
    Console.WriteLine("Đang mở file...");
    // Giả lập lỗi
    throw new FileNotFoundException("File không tồn tại!");
}
catch (FileNotFoundException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}
finally
{
    // Finally LUÔN CHẠY - dùng để dọn dẹp tài nguyên
    Console.WriteLine("🧹 Finally: Đóng file (cleanup)");
}

// ============================================
// 4️⃣ THROW - Ném exception
// ============================================
Console.WriteLine("\n--- 4. Throw Exception ---");

try
{
    int age = -5;
    ValidateAge(age);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}

void ValidateAge(int age)
{
    if (age < 0 || age > 150)
    {
        throw new ArgumentException($"Tuổi không hợp lệ: {age}");
    }
    Console.WriteLine($"Tuổi hợp lệ: {age}");
}

// ============================================
// 5️⃣ CUSTOM EXCEPTION
// ============================================
Console.WriteLine("\n--- 5. Custom Exception ---");

try
{
    WithdrawMoney(1000000, 500000);  // OK
    WithdrawMoney(1000000, 2000000); // Lỗi
}
catch (InsufficientBalanceException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
    Console.WriteLine($"   Số dư hiện tại: {ex.CurrentBalance:N0}đ");
    Console.WriteLine($"   Số tiền muốn rút: {ex.WithdrawAmount:N0}đ");
}

void WithdrawMoney(decimal balance, decimal amount)
{
    if (amount > balance)
    {
        throw new InsufficientBalanceException(balance, amount);
    }
    Console.WriteLine($"✅ Rút {amount:N0}đ thành công!");
}

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");
double Divide(int a, int b)
{
    if (b == 0)
    {
        throw new DivideByZeroException("Không thể chia cho 0");
    }
    return (double)a / b;
}

// Bài 1: Viết hàm Divide(a, b) - xử lý chia cho 0
Console.WriteLine("\n--- Bài 1: Hàm Divide (TỰ LÀM) ---");
try
{
    double result = Divide(10, 0);
    Console.WriteLine($"Kết quả: {result}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}

void ValidateEmail(string email)
{
    if (!email.Contains("@"))
    {
        throw new InvalidEmailException(email);
    }
    Console.WriteLine($"Email hợp lệ: {email}");
}

// Bài 2: Tạo Custom Exception: InvalidEmailException
// Throw khi email không chứa @ 
Console.WriteLine("\n--- Bài 2: InvalidEmailException (TỰ LÀM) ---");
try
{
    ValidateEmail("test.gmail.com"); // Thiếu @
}
catch (InvalidEmailException ex)
{
    Console.WriteLine($"❌ {ex.Message}");
}
// ============================================
// 👇 CUSTOM EXCEPTION CLASS
// ============================================
class InsufficientBalanceException : Exception
{
    public decimal CurrentBalance { get; }
    public decimal WithdrawAmount { get; }

    public InsufficientBalanceException(decimal balance, decimal amount)
        : base($"Số dư không đủ để rút {amount:N0}đ")
    {
        CurrentBalance = balance;
        WithdrawAmount = amount;
    }
}

// TODO: VIẾT CUSTOM EXCEPTION InvalidEmailException Ở ĐÂY 👇
class InvalidEmailException : Exception
{
    public InvalidEmailException(string email)
        : base($"Email không hợp lệ: {email}")
    {
    }
}
