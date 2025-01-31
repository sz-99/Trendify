
using Backend;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var dbType = DbType.InMemory;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    if (dbType == DbType.InMemory)
    {
        builder.Services.AddDbContext<WardrobeDBContext>(
                        options => options.UseInMemoryDatabase(databaseName: "WardrobeInMemory"));
    }
    else if (dbType == DbType.SqlServer)
    {
        string connectionString = builder.Configuration.GetConnectionString("WardrobeApp");
        builder.Services.AddDbContext<WardrobeDBContext>(
                        options => options.UseSqlServer(connectionString));
    }
}

builder.Services.AddScoped<IClothingItemsService, ClothingItemsService>();
builder.Services.AddScoped<IClothingItemsRepository, ClothingItemsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
