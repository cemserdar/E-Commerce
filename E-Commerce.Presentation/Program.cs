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
//        options.Cookie.Name = "E-Commerce"; // Cookie ad�
//        options.LoginPath = "/Login/Login"; // Giri� sayfas�
//        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eri�im sayfas�
//    });

builder.Services.AddAuthentication(options =>
{
    // Varsay�lan kimlik do�rulama �emas�
    options.DefaultScheme = "CookieAuth";
})
    .AddCookie("CookieAuth", options =>
    {
        options.Cookie.Name = "E-Commerce"; // �erez ad�
        options.LoginPath = "/Login"; // Giri� sayfas� yolu
        options.AccessDeniedPath = "/Account/AccessDenied"; // Yetkisiz eri�im sayfas� yolu

        // �erez se�enekleri (iste�e ba�l�)
        options.Cookie.HttpOnly = true; // �erezleri sadece HTTP �zerinden eri�ilebilir yapar
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Sadece HTTPS �zerinde kullan�lmas�n� sa�lar
        options.Cookie.SameSite = SameSiteMode.Strict; // CSRF korumas� i�in SameSite ayar�
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // �erezin ge�erlilik s�resi
        options.SlidingExpiration = true; // S�re sona ermeden kullan�c� etkinlik g�sterirse s�reyi uzat�r
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
app.UseAuthentication(); // Kimlik do�rulama middleware'i
app.UseAuthorization();  // Yetkilendirme middleware'i

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");
app.MapControllers();
app.MapRazorPages();

app.Run();

