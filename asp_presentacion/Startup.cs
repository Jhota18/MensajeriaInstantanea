using asp_servicios.Controllers;
using lib_aplicaciones.Implementaciones;
using lib_aplicaciones.Interfaces;
using lib_repositorios;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace asp_servicios
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { set; get; }

        public void ConfigureServices(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.Configure<IISServerOptions>(x => { x.AllowSynchronousIO = true; });
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddScoped<Conexion, Conexion>();
            // Repositorios
            services.AddScoped<IPersonasRepositorio, PersonasRepositorio>();
            services.AddScoped<IPersGrupsRepositorio, PersGrupsRepositorio>();
            services.AddScoped<IMensajesRepositorio, MensajesRepositorio>();
            services.AddScoped<IGruposRepositorio, GruposRepositorio>();
            services.AddScoped<IEstadosRepositorio, EstadosRepositorio>();
            services.AddScoped<IDetallesRepositorio, DetallesRepositorio>();
            // Aplicaciones
            services.AddScoped<IPersonasAplicacion, PersonasAplicacion>();
            services.AddScoped<IPersGrupsAplicacion, PersGrupsAplicacion>();
            services.AddScoped<IMensajesAplicacion, MensajesAplicacion>();
            services.AddScoped<IGruposAplicacion, GruposAplicacion>();
            services.AddScoped<IEstadosAplicacion, EstadosAplicacion>();
            services.AddScoped<IDetallesAplicacion, DetallesAplicacion>();
            // Controladores
            services.AddScoped<TokenController, TokenController>();

            services.AddCors(o => o.AddDefaultPolicy(b => b.AllowAnyOrigin()));
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            app.UseRouting();
            app.UseCors();
        }
    }
}