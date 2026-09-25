using shopweb3.Repositories;

var builder = WebApplication.CreateBuilder(args);

//----------------------------------

// Đăng ký Repository với Scope
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

//----------------------------------
// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("Default");

var app = builder.Build();

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

app.UseAuthorization();


// Route : Areas Routing (/admin/{Controller}/{Action}/{id?})
//Map với url: Admin: Tên nhãn, 
app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");
/*
name: Được dùng để nhận diện route khi bạn cần tạo URL theo tên route trong View hoặc Controller
(ví dụ sử dụng Url.RouteUrl("Tên_Route") hoặc RedirectToRoute("Tên_Route")).
area: Tên nhãn area 
*/

//Map trước, cố định với quan-tri
app.MapControllerRoute(
    name: "Qtri",
    pattern: "quan-tri/{controller=Product}/{action=Index}/{id?}",
    defaults: new { area = "Admin" }); // Cố định route này chỉ dành cho Area Admin


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
