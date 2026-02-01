// ============================================
// 📅 NGÀY 6: OOP - CLASSES & OBJECTS
// ============================================
// Mục tiêu: Hiểu Class, Object, Constructor, Properties
// Thời gian: 31/01/2026
// ĐÂY LÀ PHẦN CỰC KỲ QUAN TRỌNG!

Console.WriteLine("=== NGÀY 6: OOP - CLASSES & OBJECTS ===\n");

// ============================================
// 1️⃣ TẠO OBJECT TỪ CLASS
// ============================================
Console.WriteLine("--- 1. Tạo Object từ Class ---");

// Tạo đối tượng (object) từ class Student
Student sv1 = new Student();
sv1.Id = 1;
sv1.Name = "Nguyễn Văn An";
sv1.Age = 20;

Console.WriteLine($"SV1: {sv1.Id} - {sv1.Name} - {sv1.Age} tuổi");

// Tạo object với Constructor có tham số
Student sv2 = new Student(2, "Trần Thị Bình", 21);
Console.WriteLine($"SV2: {sv2.Id} - {sv2.Name} - {sv2.Age} tuổi");

// Gọi method của object
sv1.ShowInfo();
sv2.ShowInfo();

// ============================================
// 2️⃣ ENCAPSULATION (Đóng gói) - Private & Public
// ============================================
Console.WriteLine("\n--- 2. Encapsulation ---");

BankAccount acc = new BankAccount("ACC001", "Nguyen Van A");
acc.Deposit(1000000);    // Nạp tiền
acc.Withdraw(300000);    // Rút tiền
acc.ShowBalance();

// acc.balance = 999999999; // ❌ Không thể truy cập vì balance là private

// ============================================
// 3️⃣ PROPERTIES (Get/Set)
// ============================================
Console.WriteLine("\n--- 3. Properties ---");

Product p1 = new Product();
p1.Name = "Laptop Dell";
p1.Price = 20000000;  // Setter tự động validate
// p1.Price = -100;   // Thử uncomment: Sẽ không set vì giá âm

Console.WriteLine($"Sản phẩm: {p1.Name} - Giá: {p1.Price:N0}đ");

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP THỰC HÀNH ===");

// BÀI 1: Tạo class Employee với các properties:
// - Id, Name, Salary, Department
// - Method: ShowInfo(), CalculateBonus(percent)
Console.WriteLine("\n--- Bài 1: Class Employee (TỰ LÀM) ---");
Employee emp = new Employee(1, "Trần Văn C", 15000000, "IT");
emp.ShowInfo();
Console.WriteLine($"Bonus 10%: {emp.CalculateBonus(10)}");
// BÀI 2: Tạo class Rectangle với:
// - Properties: Width, Height (validate > 0)
// - Methods: CalculateArea(), CalculatePerimeter()
Console.WriteLine("\n--- Bài 2: Class Rectangle (TỰ LÀM) ---");
Rectangle rect = new Rectangle(10, 5);
Console.WriteLine($"Diện tích: {rect.CalculateArea()}");
Console.WriteLine($"Chu vi: {rect.CalculatePerimeter()}");

// ============================================
// 👇 ĐỊNH NGHĨA CÁC CLASS Ở ĐÂY
// ============================================

// --- CLASS STUDENT (Demo) ---
class Student
{
    // Fields (biến thành viên) - thường là private
    private int id;
    private string name = "";
    private int age;

    // Properties (thuộc tính) - public, để bên ngoài truy cập
    public int Id 
    { 
        get { return id; } 
        set { id = value; } 
    }

    public string Name 
    { 
        get { return name; } 
        set { name = value; } 
    }

    public int Age 
    { 
        get { return age; } 
        set 
        { 
            if (value >= 0 && value <= 100) // Validate tuổi
                age = value; 
        } 
    }

    // Constructor mặc định (không tham số)
    public Student() 
    {
        // Khởi tạo giá trị mặc định
    }

    // Constructor có tham số
    public Student(int id, string name, int age)
    {
        this.id = id;       // this.id = field, id = parameter
        this.name = name;
        this.age = age;
    }

    // Method (phương thức)
    public void ShowInfo()
    {
        Console.WriteLine($"📚 Sinh viên: {name}, Mã: {id}, Tuổi: {age}");
    }
}

// --- CLASS BANK ACCOUNT (Demo Encapsulation) ---
class BankAccount
{
    // Private field - chỉ truy cập được trong class này
    private decimal balance = 0;
    
    // Public properties - bên ngoài có thể đọc
    public string AccountNumber { get; private set; } // Chỉ đọc từ bên ngoài
    public string OwnerName { get; set; }

    public BankAccount(string accNumber, string owner)
    {
        AccountNumber = accNumber;
        OwnerName = owner;
    }

    // Methods public - bên ngoài gọi được
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"✅ Nạp {amount:N0}đ thành công!");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"✅ Rút {amount:N0}đ thành công!");
        }
        else
        {
            Console.WriteLine("❌ Số dư không đủ!");
        }
    }

    public void ShowBalance()
    {
        Console.WriteLine($"💰 Số dư hiện tại: {balance:N0}đ");
    }
}

// --- CLASS PRODUCT (Demo Auto-Properties với Validation) ---
class Product
{
    private decimal price;

    // Auto-implemented property (C# tự tạo field ngầm)
    public string Name { get; set; } = "";

    // Property với validation trong setter
    public decimal Price
    {
        get { return price; }
        set 
        { 
            if (value >= 0) // Không cho phép giá âm
                price = value; 
        }
    }
}

// TODO: VIẾT CLASS Employee VÀ Rectangle Ở ĐÂY 👇
//Bài 1
class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public string Department { get; set; }
    public Employee(int id, string name, decimal salary, string department)
    {
        Id = id;
        Name = name;
        Salary = salary;
        Department = department;
    }
    public void ShowInfo()
    {
        Console.WriteLine($"📚 Nhân viên: {Name}, Mã: {Id}, Lương: {Salary}, Phòng ban: {Department}");
    }
    public decimal CalculateBonus(decimal percent)
    {
        return Salary * percent / 100;
    }
}
//Bài 2
class Rectangle
{
    public int Width { get; set; }
    public int Height { get; set; }
    public Rectangle(int width, int height)
    {
        Width = width;
        Height = height;
    }
    public int CalculateArea()
    {
        return Width * Height;
    }
    public int CalculatePerimeter()
    {
        return 2 * (Width + Height);
    }
}