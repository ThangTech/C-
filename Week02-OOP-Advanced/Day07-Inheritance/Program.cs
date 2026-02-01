// ============================================
// 📅 NGÀY 7: OOP - INHERITANCE (KẾ THỪA)
// ============================================
// Mục tiêu: Hiểu Kế thừa, base class, derived class
// Thời gian: 31/01/2026
// PHẦN CỰC KỲ QUAN TRỌNG TRONG OOP!

Console.WriteLine("=== NGÀY 7: INHERITANCE (KẾ THỪA) ===\n");

// ============================================
// 1️⃣ KẾ THỪA CƠ BẢN
// ============================================
Console.WriteLine("--- 1. Kế thừa cơ bản ---");

// Tạo object từ class con
Employee emp = new Employee("Nguyễn Văn A", 25, "EMP001", 15000000);
emp.ShowInfo();

Manager mgr = new Manager("Trần Văn B", 35, "MGR001", 30000000, "IT");
mgr.ShowInfo();

// ============================================
// 2️⃣ OVERRIDE METHOD (Ghi đè phương thức)
// ============================================
Console.WriteLine("\n--- 2. Override Method ---");

// Cùng gọi ShowInfo() nhưng kết quả khác nhau
Person p1 = new Person("Người bình thường", 30);
p1.ShowInfo();

Employee e1 = new Employee("Nhân viên", 28, "E001", 10000000);
e1.ShowInfo();  // Override: In thêm EmployeeId, Salary

// ============================================
// 3️⃣ BASE KEYWORD
// ============================================
Console.WriteLine("\n--- 3. Base Keyword ---");

// Developer kế thừa Employee, gọi base constructor
Developer dev = new Developer("Lê Văn C", 26, "DEV001", 25000000, "C#");
dev.ShowInfo();
dev.Code();

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");

// Bài 1: Tạo class hierarchy cho động vật
// Animal (base) -> Dog, Cat (derived)
// - Animal có: Name, Age, Speak() (virtual)
// - Dog override Speak() -> "Gâu gâu!"
// - Cat override Speak() -> "Meo meo!"

Console.WriteLine("\n--- Bài 1: Animal Hierarchy (TỰ LÀM) ---");
Dog dog = new Dog("Milu", 3);
dog.Speak();  // Gâu gâu!
dog.ShowInfo();
Cat cat = new Cat("Kiki", 2);
cat.Speak();  // Meo meo!
cat.ShowInfo();


// ============================================
// 👇 ĐỊNH NGHĨA CÁC CLASS
// ============================================
// TODO: VIẾT CLASS Animal, Dog, Cat Ở ĐÂY 👇
class Animal{
    protected string name;
    protected int age;
    public Animal(string name, int age){
        this.name = name;
        this.age = age;
    }
    public virtual void ShowInfo(){
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
    public virtual void Speak(){
        Console.WriteLine("Animal is speaking");
    }
}
class Dog : Animal{
    public Dog(string name, int age) : base(name, age){
    }

    public override void ShowInfo(){
        base.ShowInfo();
        Console.WriteLine("Here is a dog");
    }
    public override void Speak(){
        Console.WriteLine("Gâu gâu!");
    }
}
class Cat : Animal{
    public Cat(string name, int age) : base(name, age){
    }

    public override void ShowInfo(){
        base.ShowInfo();
        Console.WriteLine("Here is a cat");
    }
    public override void Speak(){
        Console.WriteLine("Meo meo!");
    }
}
// --- BASE CLASS: PERSON ---
class Person
{
    // Protected: Class con có thể truy cập, bên ngoài không
    protected string name;
    protected int age;

    public string Name { get => name; set => name = value; }
    public int Age { get => age; set => age = value; }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    // Virtual: Cho phép class con override (ghi đè)
    public virtual void ShowInfo()
    {
        Console.WriteLine($"👤 Tên: {name}, Tuổi: {age}");
    }
}

// --- DERIVED CLASS: EMPLOYEE (Kế thừa Person) ---
class Employee : Person  // Dấu : nghĩa là kế thừa
{
    public string EmployeeId { get; set; }
    public decimal Salary { get; set; }

    // Constructor gọi base constructor của Person
    public Employee(string name, int age, string empId, decimal salary) 
        : base(name, age)  // Gọi constructor của Person
    {
        EmployeeId = empId;
        Salary = salary;
    }

    // Override: Ghi đè method của class cha
    public override void ShowInfo()
    {
        Console.WriteLine($"👔 NV: {name}, Tuổi: {age}, Mã: {EmployeeId}, Lương: {Salary:N0}đ");
    }
}

// --- DERIVED CLASS: MANAGER (Kế thừa Employee) ---
class Manager : Employee
{
    public string Department { get; set; }

    public Manager(string name, int age, string empId, decimal salary, string dept)
        : base(name, age, empId, salary)
    {
        Department = dept;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"👨‍💼 Manager: {name}, Phòng: {Department}, Lương: {Salary:N0}đ");
    }
}

// --- DERIVED CLASS: DEVELOPER (Kế thừa Employee) ---
class Developer : Employee
{
    public string ProgrammingLanguage { get; set; }

    public Developer(string name, int age, string empId, decimal salary, string lang)
        : base(name, age, empId, salary)
    {
        ProgrammingLanguage = lang;
    }

    public override void ShowInfo()
    {
        // Gọi method của class cha trước, rồi thêm thông tin
        base.ShowInfo();
        Console.WriteLine($"   💻 Ngôn ngữ: {ProgrammingLanguage}");
    }

    public void Code()
    {
        Console.WriteLine($"   ⌨️ {name} đang code bằng {ProgrammingLanguage}...");
    }
}

// TODO: VIẾT CLASS Animal, Dog, Cat Ở ĐÂY 👇
