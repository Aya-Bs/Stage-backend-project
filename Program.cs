using System.Configuration;
using Microsoft.EntityFrameworkCore;
//using ProjetStage.Business;
using StageApp.DAO;
using StageApp.Models;
using StageApp.Business;
using ProjetStage.DAO;
using ProjetStage.Business;

var builder = WebApplication.CreateBuilder(args);
var configBuilder = new ConfigurationBuilder();
configBuilder.AddJsonFile("appsettings.json");

var connectionString = configBuilder.Build().GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<BdStageContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<BdStageContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 21))));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped<ISalarieService, SalarieService>();
builder.Services.AddScoped<ICandidatureService, CandidatureService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<ISalarieService, SalarieService>();
builder.Services.AddScoped<IArchitecteService, ArchitecteService>();
builder.Services.AddScoped<IAdresseService, AdresseService>();  

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BdStageContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database connection successful.");
        }
        else
        {
            Console.WriteLine("Failed to connect to the database.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while trying to connect to the database: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
