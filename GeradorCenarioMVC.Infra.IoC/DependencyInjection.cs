using GeradorCenarioMVC.Application.Interfaces;
using GeradorCenarioMVC.Application.Mappings;
using GeradorCenarioMVC.Application.Services;
using GeradorCenarioMVC.Domain.Account;
using GeradorCenarioMVC.Domain.Interfaces;
using GeradorCenarioMVC.Infra.Data.Context;
using GeradorCenarioMVC.Infra.Data.Identity;
using GeradorCenarioMVC.Infra.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GeradorCenarioMVC.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));


			services.AddTransient<ApplicationDbContext>();


			services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
                     options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ICampanhaRepository, CampanhaRepository>();            
            services.AddScoped<IGeneroRepository, GeneroRepository>();            
            services.AddScoped<IImagemRepository, ImagemRepository>();            
            services.AddScoped<ISessaoRepository, SessaoRepository>();            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            

            services.AddScoped<ICampanhaService, CampanhaService>();            
            services.AddScoped<IGeneroService, GeneroService>();            
            services.AddScoped<IImagemService, ImagemService>();            
            services.AddScoped<ISessaoService, SessaoService>();            
            services.AddScoped<IUsuarioService, UsuarioService>();
            

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
