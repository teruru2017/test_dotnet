using Microsoft.Extensions.Options;
using octa_dotnet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using octa_dotnet.Interfaces;
using octa_dotnet.Services;
using octa_dotnet.Installers;
 
var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
//builder.Services.InstallserviceInAssembly();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IAirdropService,AirdropService>();
builder.Services.AddDbContext<DatabaseContext>(Options => 
Options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionSQLServer")));
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
