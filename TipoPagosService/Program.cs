using Microsoft.EntityFrameworkCore;
using TipoPagosService.Data;
using TipoPagosService.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PayTypeContext>(opc =>
    opc.UseSqlServer(builder.Configuration.GetConnectionString("CMPContext")));
builder.Services.AddScoped<IPayTypeRepository, PayTypeRepository>();
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
ApplyMigration();
app.Run();

void ApplyMigration()
{

    using(var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<PayTypeContext>();
        if (db.Database.GetPendingMigrations().Count() > 0) { 
            db.Database.Migrate();
        }
    }
}
