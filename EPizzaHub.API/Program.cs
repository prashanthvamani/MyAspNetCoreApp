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

builder.Services.AddSingleton<Token>();
builder.Services.AddTransient<IUserService, UserService>(); ///Registering Dependencies
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<ICartService, CartService>();


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IitemRepository, ItemRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero,
        };
    });

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
