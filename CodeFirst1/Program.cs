using Microsoft.EntityFrameworkCore;
using Domain;
using Application;
using Persistence.Database;
using Persistence.Repositories;
using WebApi.Controllers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BeerService>();
builder.Services.AddScoped<IBeerRepository, BeerRepository>();


builder.Services.AddDbContext<ApplicationContext>(options =>
{
    if (builder.Configuration.GetValue<bool>("UseSqlServer"))
    {
        var connectionString = builder.Configuration.GetConnectionString("BarConnectionSqlServer");
        options.UseSqlServer(connectionString);
    }
    else
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        var connectionString = builder.Configuration.GetConnectionString("BarConnectionMariaDB");
        options.UseMySql(connectionString, serverVersion);
    }
});


var app = builder.Build();

/*
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    context.Database.Migrate();
}
*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapBeerEndpoint();
app.MapControllers();

app.Run();
