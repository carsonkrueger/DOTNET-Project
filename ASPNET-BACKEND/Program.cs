using ASPNET_BACKEND.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Server=localhost;port=3306;User=root;Password=1002;Database=onlinestoreschema";
builder.Services.AddDbContext<OnlineStoreContext>(options => options.UseMySQL(connectionString).LogTo(Console.WriteLine, LogLevel.Information).EnableSensitiveDataLogging().EnableDetailedErrors());
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());



app.Run();
