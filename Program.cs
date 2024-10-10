using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ViteNetCoreApp.Domain.Services.AuthService;
using ViteNetCoreApp.Infrastructure.Repositories;
using ViteNetCoreApp.Infrastructure.Repositories.GenericRepository;
using ViteNetCoreApp.Infrastructure.Repositories.TasksRepository;
using ViteNetCoreApp.Infrastructure.Repositories.UserRepository;
using static ViteNetCoreApp.Infrastructure.Repositories.GenericRepository.IGenericRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 32; 
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod() 
                   .AllowAnyHeader(); 
        });
});

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<ToDoAppContext>(options=> options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<ToDoAppContext>(options=> options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITasksService, TasksService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>(); 

app.UseCors("AllowAllOrigins");

// Serve the static files (from wwwroot folder)
app.UseDefaultFiles();
app.UseStaticFiles();

// Enable routing for API endpoints
app.UseRouting();

// Enable authorization if needed
app.UseAuthorization();

// Map controllers for the API
app.MapControllers();

// Fallback to serving the React app's index.html for any unknown routes
app.MapFallbackToFile("index.html");

// Run the app
app.Run();
