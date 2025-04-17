using DispatchService.Data;
using DispatchService.Dtos;
using DispatchService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DispatchServiceContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CmpContext"));
});
builder.Services.AddScoped<ICrud<DispatchServiceResponseDto, DispatchServiceRequestDto>, DispatchServiceRepository>();
builder.Services.AddSingleton<KafkaProducer>(sp =>
    new KafkaProducer("localhost:9092"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
