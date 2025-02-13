
using Backend;
using Backend.Repositories;
using Backend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var dbType = builder.Configuration["DbType"].ToDbType();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*
if (builder.Environment.IsDevelopment())
{
    if (dbType == DbType.InMemory)
    {
        builder.Services.AddDbContext<WardrobeDBContext>(
                        options => options.UseInMemoryDatabase(databaseName: "WardrobeInMemory"));
    }
    else if (dbType == DbType.SqlServer)
    {
        builder.Services.AddDbContext<WardrobeDBContext>(
                        options => options.UseSqlServer(connectionString));
    }
}
else
{*/
    builder.Services.AddDbContext<WardrobeDBContext>(
                    options => options.UseSqlServer(connectionString));
//}

builder.Services.AddScoped<IClothingItemsService, ClothingItemsService>();
builder.Services.AddScoped<IClothingItemsRepository, ClothingItemsRepository>();
builder.Services.AddScoped<IOutfitService, OutfitService>();

builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<WardrobeDBContext>();
//    Backend.DBContext.DatabaseSeeding.SeedDatabase(context);
//}

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
