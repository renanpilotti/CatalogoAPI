using CatalogoAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers().AddJsonOptions(option => option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Always);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

string mySqlConfig = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<CatalogoAPIDbContext>(options =>
    options.UseSqlServer(mySqlConfig));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
    builder => builder.AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseCors("AllowAll");

app.MapControllers();

app.Run();
