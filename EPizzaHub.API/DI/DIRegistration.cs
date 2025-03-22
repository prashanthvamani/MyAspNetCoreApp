using EPizzaHub.Core.Concrete;
using EPizzaHub.Core.Contracts;
using EPizzaHub.Core.JWTToken;
using EPizzaHub.Repositories.Concrete;
using EPizzaHub.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EPizzaHub.API.DI
{
    public static class DIRegistration
    {
        public static IServiceCollection Registerservice(this IServiceCollection services)
        {
            services.AddSingleton<Token>();

            services.AddTransient<IUserService, UserService>(); ///Registering Dependencies
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<ICartService, CartService>();

            return services;
        }

        public static IServiceCollection RegisterDBdependency(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IitemRepository, ItemRepository>();
            services.AddScoped<ICartRepository, CartRepository>();

            return services;
        }

        public static IServiceCollection JwtRegisterservice(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"])),
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            ClockSkew = TimeSpan.Zero,
        };
    });

            return services;
        }
    }
}
