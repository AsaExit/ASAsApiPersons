using ASAsApiPersons.Data;
using ASAsApiPersons.Models.Repo;
using ASAsApiPersons.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPeopleRepo, PeopleRepo>();
builder.Services.AddScoped<IPeopleService, PeopleService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowAllOrigins",
                      builder =>
                      {
                          builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "people API",
        Version = "v1"
    });
});



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "people API"); });
app.MapControllers();


app.Run();
