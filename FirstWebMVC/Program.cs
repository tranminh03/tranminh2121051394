using FirstWebMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FirstWebMVC.Models;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.CodeAnalysis.Options;
using Microsoft.AspNetCore.Identity.UI.Services;
using FirstWebMVC.Models.Process;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOptions();
var mailSettings = builder.Configuration.GetSection("MailSettings");
builder.Services.AddTransient<IEmailSender, SendMailService>();
builder.Services.Configure<MailSettings>(mailSettings);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")
?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    foreach (var permission in Enum.GetValues(typeof(SystemPermissions)).Cast<SystemPermissions>())
    {
        options.AddPolicy(permission.ToString(), policy =>
        policy.RequireClaim("Permission", permission.ToString()));
    }
    // options.AddPolicy("Role",policy =>policy.RequireClaim("Role","AdminOnly"));
    // options.AddPolicy("Permission",policy =>policy.RequireClaim("Role","StudentOnly"));
    // options.AddPolicy("PolicyAdmin",policy =>policy.RequireRole("Admin"));
    // options.AddPolicy("PolicyStudent",policy =>policy.RequireRole("Student"));
    // options.AddPolicy("PolicyByPhoneNumber",policy =>policy.Requirements.Add(new PolicyByPhoneNumberRequirement()));
});
builder.Services.AddSingleton<IAuthorizationHandler, PolicyByPhoneNumberHandler>();
// Cấu hình các tùy chọn Identity cho ASP.NET Core
builder.Services.Configure<IdentityOptions>(options =>
{
    //Khóa Tài Khoản
    // Thiết lập thời gian khóa tài khoản mặc định là 5 phút
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    // Giới hạn số lần đăng nhập sai tối đa là 5 lần
    options.Lockout.MaxFailedAccessAttempts = 5;

    // Cho phép áp dụng cơ chế khóa tài khoản cho cả người dùng mới
    options.Lockout.AllowedForNewUsers = true;



    // Config Password - Cấu hình yêu cầu đối với mật khẩu người dùng

    // Yêu cầu mật khẩu phải chứa ít nhất một chữ số (0-9)
    options.Password.RequireDigit = true;

    // Đặt độ dài tối thiểu của mật khẩu là 8 ký tự
    options.Password.RequiredLength = 8;

    // Cho phép mật khẩu chứa các kí tự đặc biệt
    options.Password.RequireNonAlphanumeric = false;

    // Yêu cầu mật khẩu phải có ít nhất một ký tự in hoa (A-Z)
    options.Password.RequireUppercase = true;

    // Không bắt buộc mật khẩu phải chứa ký tự in thường (a-z)
    options.Password.RequireLowercase = false;



    // Config Login - Cấu hình yêu cầu khi đăng nhập

    // Không yêu cầu người dùng phải xác nhận email để có thể đăng nhập
    options.SignIn.RequireConfirmedEmail = false;

    // Không yêu cầu người dùng phải xác nhận số điện thoại để có thể đăng nhập
    options.SignIn.RequireConfirmedPhoneNumber = false;



    // Config User - Cấu hình yêu cầu đối với người dùng

    // Yêu cầu email của mỗi người dùng phải là duy nhất
    options.User.RequireUniqueEmail = true;
});


builder.Services.ConfigureApplicationCookie(options =>
{
    // Chỉ cho phép cookie được truy cập qua HTTP, không thể truy cập qua JavaScript(tăng cường bảo mật, giảm nguy cơ bị tấn công XSS)
    options.Cookie.HttpOnly = true;

    // Chỉ gửi cookie qua các kết nối HTTPS(Bảo vệ cookie khỏi bị đánh cắp trong các kết nối không an toàn)
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;

    // Giảm thiểu nguy cơ tấn công CSRF bằng cách chỉ cho phép cookie được gửi trong một số điều kiện
    // "Lax" cho phép gửi cookie khi người dùng nhấp vào liên kết từ trang khác đến trang này
    options.Cookie.SameSite = SameSiteMode.Lax;

    // Thiết lập thời gian tồn tại của cookie là 60 phút
    // Sau 60 phút, người dùng sẽ cần phải đăng nhập lại
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);

    // Đường dẫn đến trang đăng nhập nếu người dùng chưa xác thực
    options.LoginPath = "/Account/Login";

    // Đường dẫn đến trang "Truy cập bị từ chối" nếu người dùng không có quyền truy cập
    options.AccessDeniedPath = "/Account/AccessDenied";

    // Bật tính năng "sliding expiration" cho cookie
    // Nếu người dùng hoạt động trước khi hết hạn, thời gian hết hạn sẽ được làm mới
    options.SlidingExpiration = true;
});


builder.Services.AddDataProtection()

    // Xác định thư mục lưu trữ khóa bảo vệ dữ liệu
    .PersistKeysToFileSystem(new DirectoryInfo(@"./keys"))

    // Đặt tên cho ứng dụng sử dụng dịch vụ bảo vệ dữ liệu
    .SetApplicationName("YourAppName")

    // Thiết lập thời gian tồn tại của khóa bảo vệ dữ liệu 
    .SetDefaultKeyLifetime(TimeSpan.FromDays(14));



builder.Services.AddRazorPages();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => 
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddTransient<Employee2Seeder>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

var app = builder.Build();

//Employee2Seeder
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<Employee2Seeder>();
    seeder.SeedEmployee2s(1000);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();