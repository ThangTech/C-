// ============================================
// 📅 NGÀY 8: POLYMORPHISM & ABSTRACT CLASS
// ============================================
// Mục tiêu: Hiểu Đa hình, Abstract class, Sealed class
// Thời gian: 01/02/2026

Console.WriteLine("=== NGÀY 8: POLYMORPHISM & ABSTRACT ===\n");

// ============================================
// 1️⃣ POLYMORPHISM (Đa hình)
// ============================================
Console.WriteLine("--- 1. Polymorphism ---");

// Tạo mảng chứa nhiều loại Shape khác nhau
Shape[] shapes = new Shape[]
{
    new Circle(5),
    new Rectangle(4, 6),
    new Triangle(3, 4)
};

// Cùng gọi Draw() nhưng mỗi loại vẽ khác nhau - ĐÂY LÀ POLYMORPHISM!
foreach (Shape shape in shapes)
{
    shape.Draw();
    Console.WriteLine($"   Diện tích: {shape.CalculateArea()}");
}

// ============================================
// 2️⃣ ABSTRACT CLASS
// ============================================
Console.WriteLine("\n--- 2. Abstract Class ---");

// Shape shape = new Shape(); // ❌ LỖI! Không thể tạo object từ abstract class
Circle c = new Circle(10);
c.Draw();
Console.WriteLine($"Chu vi: {c.CalculatePerimeter()}");

// ============================================
// 3️⃣ SEALED CLASS (Không cho kế thừa)
// ============================================
Console.WriteLine("\n--- 3. Sealed Class ---");

FinalClass final = new FinalClass();
final.DoSomething();
// class ChildOfFinal : FinalClass { } // ❌ LỖI! Không thể kế thừa sealed class

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");

// Bài 1: Tạo hệ thống thanh toán
// abstract class Payment { abstract void Pay(decimal amount); }
// CreditCard, BankTransfer, EWallet kế thừa Payment

Console.WriteLine("\n--- Bài 1: Payment System (TỰ LÀM) ---");
Payment[] payments = { new CreditCard(), new BankTransfer(), new EWallet() };
foreach (var p in payments) p.Pay(100000);


// ============================================
// 👇 ĐỊNH NGHĨA CÁC CLASS
// ============================================

abstract class Payment
{
    public abstract void Pay(decimal amount);
}

class CreditCard : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Thanh toán {amount} qua Credit Card");
    }
}

class BankTransfer : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Thanh toán {amount} qua Ngân hàng");
    }
}

class EWallet : Payment
{
    public override void Pay(decimal amount)
    {
        Console.WriteLine($"Thanh toán {amount} qua ví điện tử");
    }
}

// --- ABSTRACT CLASS: SHAPE ---
abstract class Shape
{
    public string Name { get; set; } = "";
    
    // Abstract method: KHÔNG có body, class con BẮT BUỘC phải override
    public abstract double CalculateArea();
    public abstract double CalculatePerimeter();
    
    // Virtual method: CÓ body mặc định, class con CÓ THỂ override
    public virtual void Draw()
    {
        Console.WriteLine($"🎨 Vẽ hình: {Name}");
    }
}

// --- CONCRETE CLASS: CIRCLE ---
class Circle : Shape
{
    public double Radius { get; set; }
    
    public Circle(double radius)
    {
        Radius = radius;
        Name = "Hình tròn";
    }
    
    // BẮT BUỘC override vì CalculateArea là abstract
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }
    
    public override double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }
    
    public override void Draw()
    {
        Console.WriteLine($"⭕ Vẽ hình tròn, bán kính = {Radius}");
    }
}

// --- CONCRETE CLASS: RECTANGLE ---
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    
    public Rectangle(double w, double h)
    {
        Width = w;
        Height = h;
        Name = "Hình chữ nhật";
    }
    
    public override double CalculateArea() => Width * Height;
    
    public override double CalculatePerimeter() => 2 * (Width + Height);
    
    public override void Draw()
    {
        Console.WriteLine($"🟦 Vẽ HCN {Width}x{Height}");
    }
}

// --- CONCRETE CLASS: TRIANGLE ---
class Triangle : Shape
{
    public double Base { get; set; }
    public double Height { get; set; }
    
    public Triangle(double b, double h)
    {
        Base = b;
        Height = h;
        Name = "Tam giác";
    }
    
    public override double CalculateArea() => 0.5 * Base * Height;
    
    public override double CalculatePerimeter()
    {
        // Giả sử tam giác vuông
        double hypotenuse = Math.Sqrt(Base * Base + Height * Height);
        return Base + Height + hypotenuse;
    }
    
    public override void Draw()
    {
        Console.WriteLine($"🔺 Vẽ tam giác, đáy = {Base}, cao = {Height}");
    }
}

// --- SEALED CLASS (Không cho kế thừa) ---
sealed class FinalClass
{
    public void DoSomething()
    {
        Console.WriteLine("🔒 Sealed class - Không ai có thể kế thừa tôi!");
    }
}

// TODO: VIẾT CLASS Payment, CreditCard, BankTransfer, EWallet Ở ĐÂY 👇
