using E_Commerce.Application.Interfaces;
using E_Commerce.Application.Services;
using E_Commerce.Infrastructure.Data;
using E_Commerce.Infrastucture.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

//builder.Services.AddAuthentication("CookieAuth")
//    .AddCookie("CookieAuth", options =>
//    {
//        options.Cookie.Name = "E-Commerce"; // Cookie adý
//        options.LoginPath = "/Login/Login"; // Giriþ sayfasý
//        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eriþim sayfasý
//    });

builder.Services.AddAuthentication(options =>
{
    // Varsayýlan kimlik doðrulama þemasý
    options.DefaultScheme = "CookieAuth";
})
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "E-Commerce"; // Çerez adý
        options.LoginPath = "/Login"; // Giriþ sayfasý yolu
        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eriþim sayfasý yolu

        // Çerez seçenekleri (isteðe baðlý)
        options.Cookie.HttpOnly = true; // Çerezleri sadece HTTP üzerinden eriþilebilir yapar
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Sadece HTTPS üzerinde kullanýlmasýný saðlar
        options.Cookie.SameSite = SameSiteMode.Strict; // CSRF korumasý için SameSite ayarý
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Çerezin geçerlilik süresi
        options.SlidingExpiration = true; // Süre sona ermeden kullanýcý etkinlik gösterirse süreyi uzatýr
    });




builder.Services.AddDbContext<ECommerceDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("constr"), b => b.MigrationsAssembly("E-Commerce.Presentation")));


builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<BasketRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<CategoryRepository>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ProductRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers()
//    .AddJsonOptions(options =>
//    {
//        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
//        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
//    });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();




var app = builder.Build();
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication(); // Kimlik doðrulama middleware'i
app.UseAuthorization();  // Yetkilendirme middleware'i

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.MapControllers();
app.MapRazorPages();

app.Run();

