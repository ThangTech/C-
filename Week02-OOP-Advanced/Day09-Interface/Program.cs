// ============================================
// 📅 NGÀY 9: INTERFACE
// ============================================
// Mục tiêu: Hiểu Interface, Multiple Interface, Interface vs Abstract
// Thời gian: 01/02/2026
// ĐÂY LÀ NỀN TẢNG CHO DEPENDENCY INJECTION TRONG ASP.NET CORE!

Console.WriteLine("=== NGÀY 9: INTERFACE ===\n");

// ============================================
// 1️⃣ INTERFACE CƠ BẢN
// ============================================
Console.WriteLine("--- 1. Interface Cơ Bản ---");

// Interface định nghĩa "hợp đồng" - class nào implement phải có đủ methods
ILogger consoleLogger = new ConsoleLogger();
consoleLogger.Log("Đây là log message");
consoleLogger.LogError("Đây là error!");

ILogger fileLogger = new FileLogger();
fileLogger.Log("Ghi log vào file...");

// ============================================
// 2️⃣ MULTIPLE INTERFACES (Đa kế thừa Interface)
// ============================================
Console.WriteLine("\n--- 2. Multiple Interfaces ---");

// C# không cho đa kế thừa class, NHƯNG cho phép implement nhiều interface
SmartPhone phone = new SmartPhone("iPhone 15");
phone.Call("0123456789");
phone.TakePhoto();
phone.PlayMusic("Shape of You");

// ============================================
// 3️⃣ INTERFACE TRONG THỰC TẾ (Dependency Injection Preview)
// ============================================
Console.WriteLine("\n--- 3. Dependency Injection Preview ---");

// Thay vì phụ thuộc vào class cụ thể:
// OrderService service = new OrderService(new SqlDatabase());

// Chúng ta phụ thuộc vào Interface:
IDatabase db = new SqlDatabase();
// IDatabase db = new MongoDatabase(); // ← Dễ dàng đổi sang MongoDB!

OrderService orderService = new OrderService(db);
orderService.CreateOrder("ORD001");

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");

// Bài 1: Tạo interface IShape với:
// - double CalculateArea();
// - double CalculatePerimeter();
// Implement cho: Circle, Square

Console.WriteLine("\n--- Bài 1: IShape Interface (TỰ LÀM) ---");
IShape circle = new Circle(5);
IShape square = new Square(4);
Console.WriteLine($"Circle Area: {circle.CalculateArea()}");
Console.WriteLine($"Square Perimeter: {square.CalculatePerimeter()}");


// ============================================
// 👇 ĐỊNH NGHĨA CÁC INTERFACE & CLASS
// ============================================
interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
}
class Circle : IShape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Radius = radius;
    }
    
    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    
    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}
class Square : IShape
{
    public double Side { get; set; }
    
    public Square(double side)
    {
        Side = side;
    }
    
    public double CalculateArea()
    {
        return Side * Side;
    }
    
    public double CalculatePerimeter()
    {
        return 4 * Side;
    }
}
// --- INTERFACE: ILOGGER ---
interface ILogger
{
    void Log(string message);
    void LogError(string error);
    
    // Default implementation (C# 8+)
    void LogWarning(string warning)
    {
        Console.WriteLine($"⚠️ WARNING: {warning}");
    }
}

// --- CLASS IMPLEMENT ILOGGER ---
class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"📝 [Console] {message}");
    }
    
    public void LogError(string error)
    {
        Console.WriteLine($"❌ [Console Error] {error}");
    }
}

class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"📁 [File] Ghi vào file: {message}");
    }
    
    public void LogError(string error)
    {
        Console.WriteLine($"📁 [File Error] {error}");
    }
}

// --- MULTIPLE INTERFACES ---
interface IPhone
{
    void Call(string number);
}

interface ICamera
{
    void TakePhoto();
}

interface IMusicPlayer
{
    void PlayMusic(string song);
}

// SmartPhone implement 3 interfaces cùng lúc!
class SmartPhone : IPhone, ICamera, IMusicPlayer
{
    public string Model { get; set; }
    
    public SmartPhone(string model)
    {
        Model = model;
    }
    
    public void Call(string number)
    {
        Console.WriteLine($"📞 {Model}: Đang gọi {number}...");
    }
    
    public void TakePhoto()
    {
        Console.WriteLine($"📷 {Model}: *Click* Chụp ảnh!");
    }
    
    public void PlayMusic(string song)
    {
        Console.WriteLine($"🎵 {Model}: Đang phát '{song}'");
    }
}

// --- DEPENDENCY INJECTION EXAMPLE ---
interface IDatabase
{
    void Save(string data);
    string Get(string id);
}

class SqlDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine($"💾 SQL Server: Saved '{data}'");
    }
    
    public string Get(string id)
    {
        return $"Data from SQL: {id}";
    }
}

class MongoDatabase : IDatabase
{
    public void Save(string data)
    {
        Console.WriteLine($"🍃 MongoDB: Saved '{data}'");
    }
    
    public string Get(string id)
    {
        return $"Data from Mongo: {id}";
    }
}

// Service phụ thuộc vào Interface, không phụ thuộc vào class cụ thể
class OrderService
{
    private readonly IDatabase _database;
    
    // Constructor Injection - Inject interface vào
    public OrderService(IDatabase database)
    {
        _database = database;
    }
    
    public void CreateOrder(string orderId)
    {
        _database.Save($"Order: {orderId}");
        Console.WriteLine($"✅ Đơn hàng {orderId} đã được tạo!");
    }
}

// TODO: VIẾT INTERFACE IShape VÀ CLASS Circle, Square Ở ĐÂY 👇
