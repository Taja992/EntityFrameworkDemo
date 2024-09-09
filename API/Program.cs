

using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    //options.UseSqlite("Data Source=../DataAccess/mydatabase.db");
    options.UseNpgsql(builder.Configuration.GetConnectionString("MyDbConn"));
});

builder.Services.AddControllers();


var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetService<MyDbContext>();
    if (dbContext != null)
    {
        dbContext.Database.EnsureCreated();
    }
    else
    {
        throw new InvalidOperationException("DbContext is not registered.");
    }
}

app.MapControllers();

app.Run();