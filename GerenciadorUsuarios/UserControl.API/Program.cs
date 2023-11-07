using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.Context;

var builder = WebApplication.CreateBuilder(args);
var client = "http://localhost:4200";

// Outras configurações de serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configura o HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader().WithOrigins(client));

app.UseHttpsRedirection();
app.UseAuthorization();

//Migra o banco de dados para a versão mais recente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

app.MapControllers();
app.Run();
