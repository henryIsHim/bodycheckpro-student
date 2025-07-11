using BodyCheckWebAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BodyCheckDbContext>(
    options => options.UseSqlite(builder.Configuration.GetConnectionString("MySQLiteDb"))
);

// Ensure Data directory exists
var dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Data");
if (!Directory.Exists(dataDirectory))
{
    Directory.CreateDirectory(dataDirectory);
}

//Configure CORS policy
builder.Services.AddCors(options => {
    options.AddPolicy("RestrictedOrigins",policy => {
        if (builder.Environment.IsDevelopment())
        {
            policy.WithOrigins("https://localhost:5115", "http://localhost:5115", "https://localhost:7121", "http://localhost:7121", "https://localhost:7766", "http://localhost:6677")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
        else
        {
            // Production domains - Railway deployment
            policy.WithOrigins("https://bodycheckpro-student-mvc.up.railway.app", "https://*.up.railway.app")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BodyCheckDbContext>();
    context.Database.EnsureCreated();
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

app.UseCors("RestrictedOrigins");

app.UseRouting();
app.MapControllers();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
        c.RoutePrefix = string.Empty; // Set Swager UI as root of the app
    });
}



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();