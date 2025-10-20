using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Add DbContext with SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

//Controllers
builder.Services.AddControllers();


//CORS for Vue
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();

app.MapGet("/api/test", () => new {message = "Backend is working"});

//Use CORS
app.UseCors("AllowAll");

//Map Controllers
app.MapControllers();

app.Run();
