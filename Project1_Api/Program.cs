using BBL.AuthService;
using BBL.ECommerceServices.CategoryService;
using BBL.ECommerceServices.OrderService;
using BBL.ECommerceServices.ProductService;
using BBL.ECommerceServices.ShoppingServices;
using DAL.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Project1_Api.AuthService;
using Project1_Api.Exception;
using Project1_Api.NewFolder;
using Serilog;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
//-----------------

builder.Services.AddHttpContextAccessor();
//---------adding db context service
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),x=>x.MigrationsAssembly("DAL"));
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


//----------------jwt service-------------

builder.Services.AddScoped<IAuthService,AuthService>(); 

var jwtsettings = new JwtSettings();

builder.Configuration.GetSection("JwtSettings").Bind(jwtsettings);

builder.Services.AddSingleton(jwtsettings);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtsettings.Issuer,
        ValidAudience = jwtsettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.SecretKey)),
        RoleClaimType = ClaimTypes.Role 
    };
});


//----------adding email service

builder.Services.AddTransient<IEmailService,EmailService>();

//----------adding ecommerce related services

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Project1 API", Version = "v1" });

    // JWT support
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    var securityRequirement = new OpenApiSecurityRequirement
    {
        { securityScheme, new[] { "Bearer" } }
    };

    c.AddSecurityRequirement(securityRequirement);
});


//--------------configuring logging

builder.Host.UseSerilog((HostBuilderContext context,
    IServiceProvider services, LoggerConfiguration loggerConfiguration) =>
{
    //Reading Configuration from Built-in IConfiguration 
    loggerConfiguration.ReadFrom.Configuration(context.Configuration)
    //services and make avilable them to serilog
    .ReadFrom.Services(services);
});


var app = builder.Build();

//app.Logger.LogDebug("debug-message");
//app.Logger.LogInformation("information message");
//app.Logger.LogWarning("log message");
//app.Logger.LogError("error message");
//app.Logger.LogCritical("critical message");

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
