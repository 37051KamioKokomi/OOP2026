using Microsoft.EntityFrameworkCore; // UseSqlServer を使用
using MvcBasicSample.Data; // AppDbContext を使用

var builder = WebApplication.CreateBuilder(args);

// Controller とView を使うMVC の機能を登録する
builder.Services.AddControllersWithViews();

// DefaultConnection という名前の接続文字列を取得する
var connectionString = builder.Configuration
.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("接続文字列がありません");
// AppDbContext を生成するときに使用するSQL Server の接続設定を登録する
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build(); // 設定からアプリを生成

// 開発環境以外で使うエラー画面とHTTPS の設定
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // HTTP からHTTPS へ転送
app.UseStaticFiles(); // wwwroot にあるCSS やJavaScript などを配信

app.UseRouting(); // URL とController のAction を対応付ける

app.UseAuthorization(); // 設定されているアクセス許可を確認

// URL をController とAction に対応付ける
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Web サーバーを起動して要求の受信を開始
