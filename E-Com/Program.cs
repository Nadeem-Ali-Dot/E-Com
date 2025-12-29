using E_Com.Models;
using E_Com.Models.Repository.Contract;
using E_Com.Models.Repository.Service;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IGeneric<>),typeof(Services<>));
builder.Services.AddOpenApi();



var app = builder.Build();



// Configure the HTTP request pipeline
app.MapOpenApi();

// ✅ Optional: Add Swagger-like UI using Scalar (new UI tool)
app.MapScalarApiReference(options =>
{
    options.Title = "E-Com API";
    options.Theme = ScalarTheme.Purple; // You can choose Light, Purple, etc.
});

app.UseStaticFiles();

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();
app.Run();

