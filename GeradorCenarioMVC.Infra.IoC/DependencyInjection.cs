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
            services.AddScoped<ICategoriaMateriaRepository, CategoriaMateriaRepository>();
            services.AddScoped<ICenarioGeneroRepository, CenarioGeneroRepository>();
            services.AddScoped<ICenarioRepository, CenarioRepository>();
            services.AddScoped<IConquistaRepository, ConquistaRepository>();
            services.AddScoped<IEnredoRepository, EnredoRepository>();
            services.AddScoped<IGaleriaRepository, GaleriaRepository>();
            services.AddScoped<IGrupoRepository, GrupoRepository>();
            services.AddScoped<IImagemRepository, ImagemRepository>();
            services.AddScoped<IMapaRepository, MapaRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<IMissaoRepository, MissaoRepository>();
            services.AddScoped<INpcRepository, NpcRepository>();
            services.AddScoped<IPcRepository, PcRepository>();
            services.AddScoped<ISecaoCabecalhoRepository, SecaoCabecalhoRepository>();
            services.AddScoped<ISecaoLateralRepository, SecaoLateralRepository>();
            services.AddScoped<ISecaoRodapeRepository, SecaoRodapeRepository>();
            services.AddScoped<ISessaoRepository, SessaoRepository>();
            services.AddScoped<IStatusMissaoRepository, StatusMissaoRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITipoConquistaRepository, TipoConquistaRepository>();
            services.AddScoped<ITipoMateriaRepository, TipoMateriaRepository>();
            services.AddScoped<ITipoMissaoRepository, TipoMissaoRepository>();
            services.AddScoped<ITipoNpcRepository, TipoNpcRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            

            services.AddScoped<ICampanhaService, CampanhaService>();
            services.AddScoped<ICategoriaMateriaService, CategoriaMateriaService>();
            services.AddScoped<ICenarioGeneroService, CenarioGeneroService>();
            services.AddScoped<ICenarioService, CenarioService>();
            services.AddScoped<IConquistaService, ConquistaService>();
            services.AddScoped<IEnredoService, EnredoService>();
            services.AddScoped<IGaleriaService, GaleriaService>();
            services.AddScoped<IGrupoService, GrupoService>();
            services.AddScoped<IImagemService, ImagemService>();
            services.AddScoped<IMapaService, MapaService>();
            services.AddScoped<IMateriaService, MateriaService>();
            services.AddScoped<IMissaoService, MissaoService>();
            services.AddScoped<INpcService, NpcService>();
            services.AddScoped<IPcService, PcService>();
            services.AddScoped<ISecaoCabecalhoService, SecaoCabecalhoService>();
            services.AddScoped<ISecaoLateralService, SecaoLateralService>();
            services.AddScoped<ISecaoRodapeService, SecaoRodapeService>();
            services.AddScoped<ISessaoService, SessaoService>();
            services.AddScoped<IStatusMissaoService, StatusMissaoService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITipoConquistaService, TipoConquistaService>();
            services.AddScoped<ITipoMateriaService, TipoMateriaService>();
            services.AddScoped<ITipoMissaoService, TipoMissaoService>();
            services.AddScoped<ITipoNpcService, TipoNpcService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
