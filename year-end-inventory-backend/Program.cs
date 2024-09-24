
using Microsoft.EntityFrameworkCore;
using year_end_inventory_backend.Models;

var builder = WebApplication.CreateBuilder(args);
string? connectionStringSOS = builder.Configuration.GetConnectionString("MsSqlConnectionSOS");
string? connectionStringUnrestricted = builder.Configuration.GetConnectionString("MsSqlConnectionUnrestricted");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<SosTicketDbContext>(options => options.UseSqlServer(connectionStringSOS));
builder.Services.AddDbContext<UnrestrictedTicketDbContext>(options => options.UseSqlServer(connectionStringUnrestricted));

var app = builder.Build();
app.UseDeveloperExceptionPage();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
