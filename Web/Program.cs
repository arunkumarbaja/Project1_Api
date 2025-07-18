using BBL.ECommerceServices.ShoppingServices;
using DAL.Data;
using Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project1_Api.NewFolder;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();


builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();


builder.Services.AddScoped<IEmailService, EmailService>();


//---------adding db context service
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), x => x.MigrationsAssembly("DAL"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "MyAuthCookie";
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    });



// --------adding identity service
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();



builder.Services.AddAuthorization();



builder.Services.AddHttpContextAccessor();


builder.Services.AddAuthorization();



//--------configuring logging
builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    //Reading Configuration from Built-in IConfiguration 
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
    //services and make avilable them to serilog
    .ReadFrom.Services(services);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.Logger.LogDebug("debug-message");
app.Logger.LogInformation("information message");
app.Logger.LogWarning("log message");
app.Logger.LogError("error message");
app.Logger.LogCritical("critical message");

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
