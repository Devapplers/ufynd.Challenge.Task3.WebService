using Task3.WebService.Configs;
using Task3.WebService.Repositories;
using Task3.WebService.Services;
using Task3.WebService.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<Files>(builder.Configuration.GetSection("Files"));
builder.Services.AddSingleton<IJsonHandler, JsonHandler>();
builder.Services.AddTransient<IHotelsRatesRepository, HotelsRatesRepository>();
builder.Services.AddTransient<IHotelRateRepository, HotelRateRepository>();
builder.Services.AddTransient<IHotelRateService, HotelRatesService>();
builder.Services.AddTransient<IHotelRateService, HotelRatesService>();

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
