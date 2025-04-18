using EPizzaHub.API.DI;
using EPizzaHub.API.Middleware;
using EPizzaHub.Core.Concrete;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.JWTToken;
using EPizzaHub.Domain.Models;
using EPizzaHub.Repositories.Concrete;
using EPizzaHub.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ePizzaHubDBContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});

builder.Services.RegisterDBdependency()
    .Registerservice()
    .JwtRegisterservice(builder.Configuration);



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CommonResponseMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
