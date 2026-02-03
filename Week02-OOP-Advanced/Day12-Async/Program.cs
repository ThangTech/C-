// ============================================
// 📅 NGÀY 12: ASYNC/AWAIT
// ============================================
// Mục tiêu: Lập trình bất đồng bộ - Không chặn UI
// Thời gian: 03/02/2026
// QUAN TRỌNG CHO WEB API (HttpClient, Database, File I/O)

Console.WriteLine("=== NGÀY 12: ASYNC/AWAIT ===\n");

// ============================================
// 1️⃣ SYNC vs ASYNC
// ============================================
Console.WriteLine("--- 1. Sync vs Async ---");

// SYNC: Chờ từng tác vụ hoàn thành
Console.WriteLine("[Sync] Bắt đầu...");
Thread.Sleep(1000); // Chờ 1 giây - CHẶN thread!
Console.WriteLine("[Sync] Xong sau 1s");

// ASYNC: Không chặn, tiếp tục các việc khác
Console.WriteLine("\n[Async] Bắt đầu...");
await Task.Delay(1000); // Chờ 1 giây - KHÔNG chặn!
Console.WriteLine("[Async] Xong sau 1s");

// ============================================
// 2️⃣ ASYNC METHOD CƠ BẢN
// ============================================
Console.WriteLine("\n--- 2. Async Method ---");

// Gọi async method và await kết quả
string data = await FetchDataAsync();
Console.WriteLine($"Dữ liệu: {data}");

// Async method trả về Task<T>
async Task<string> FetchDataAsync()
{
    Console.WriteLine("   Đang tải dữ liệu...");
    await Task.Delay(500); // Giả lập gọi API
    return "Dữ liệu từ server";
}

// ============================================
// 3️⃣ CHẠY NHIỀU TASKS SONG SONG
// ============================================
Console.WriteLine("\n--- 3. Parallel Tasks ---");

var stopwatch = System.Diagnostics.Stopwatch.StartNew();

// Chạy 3 tasks SONG SONG (không chờ từng cái)
Task<string> task1 = DownloadAsync("File1.txt", 1000);
Task<string> task2 = DownloadAsync("File2.txt", 800);
Task<string> task3 = DownloadAsync("File3.txt", 1200);

// Chờ TẤT CẢ hoàn thành
string[] results = await Task.WhenAll(task1, task2, task3);

stopwatch.Stop();
Console.WriteLine($"Tất cả hoàn thành trong {stopwatch.ElapsedMilliseconds}ms");
// Nếu chạy tuần tự: 1000 + 800 + 1200 = 3000ms
// Chạy song song: ~1200ms (lấy cái lâu nhất)

foreach (var r in results)
    Console.WriteLine($"   {r}");

async Task<string> DownloadAsync(string filename, int delayMs)
{
    await Task.Delay(delayMs);
    return $"✅ {filename} đã tải xong ({delayMs}ms)";
}

// ============================================
// 4️⃣ XỬ LÝ EXCEPTION TRONG ASYNC
// ============================================
Console.WriteLine("\n--- 4. Exception trong Async ---");

try
{
    await FailingTaskAsync();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"❌ Bắt được lỗi: {ex.Message}");
}

async Task FailingTaskAsync()
{
    await Task.Delay(100);
    throw new InvalidOperationException("Async task failed!");
}

// ============================================
// 5️⃣ THỰC TẾ: GỌI API (HttpClient)
// ============================================
Console.WriteLine("\n--- 5. HttpClient (Real API) ---");

using HttpClient client = new HttpClient();
try
{
    // Gọi API thật
    string response = await client.GetStringAsync("https://api.github.com/zen");
    Console.WriteLine($"GitHub Zen: {response}");
}
catch (HttpRequestException ex)
{
    Console.WriteLine($"❌ Lỗi HTTP: {ex.Message}");
}

// ============================================
// 🎯 BÀI TẬP THỰC HÀNH
// ============================================
Console.WriteLine("\n=== BÀI TẬP ===");

// Bài 1: Viết async method GetUserAsync(int id)
// Giả lập delay 500ms, trả về "User_{id}"
Console.WriteLine("\n--- Bài 1: GetUserAsync (TỰ LÀM) ---");
string user = await GetUserAsync(123);
Console.WriteLine(user);
async Task<string> GetUserAsync(int id)
{
    await Task.Delay(5000);
    return $"User_{id}";
}
// Bài 2: Gọi GetUserAsync cho 5 user (1-5) SONG SONG
// Dùng Task.WhenAll
Console.WriteLine("\n--- Bài 2: Parallel GetUser (TỰ LÀM) ---");
var tasks = new Task<string>[]
{
    GetUserAsync(1),
    GetUserAsync(2),
    GetUserAsync(3),
    GetUserAsync(4),
    GetUserAsync(5)
};
var users = await Task.WhenAll(tasks);
foreach (var u in users)
    Console.WriteLine(u);

