using AccountingconceptService.Data;
using AccountingconceptService.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountingConceptContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("CMPContext"))
);
builder.Services.AddScoped<IAccountingConceptRepository, AccountingConceptRepository>();
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

void ApplyMigration() {
    using (var scope = app.Services.CreateScope()) { 
        var db = scope.ServiceProvider.GetRequiredService<AccountingConceptContext>();
        if (db.Database.GetPendingMigrations().Count() > 0)
            db.Database.Migrate();
    }
}