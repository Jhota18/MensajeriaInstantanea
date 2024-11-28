using lib_comunicaciones.Implementaciones;
using lib_comunicaciones.Interfaces;
using lib_presentaciones.Implementaciones;
using lib_presentaciones.Interfaces;

namespace asp_presentacion
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
            // Comunicaciones
            services.AddScoped<IPersonasComunicacion, PersonasComunicacion>();
            services.AddScoped<IPersGrupsComunicacion, PersGrupsComunicacion>();
            services.AddScoped<IMensajesComunicacion, MensajesComunicacion>();
            services.AddScoped<IGruposComunicacion, GruposComunicacion>();
            services.AddScoped<IEstadosComunicacion, EstadosComunicacion>();
            services.AddScoped<IDetallesComunicacion, DetallesComunicacion>();

            // Presentaciones
            services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
            services.AddScoped<IPersGrupsPresentacion, PersGrupsPresentacion>();
            services.AddScoped<IMensajesPresentacion, MensajesPresentacion>();
            services.AddScoped<IGruposPresentacion, GruposPresentacion>();
            services.AddScoped<IEstadosPresentacion, EstadosPresentacion>();
            services.AddScoped<IDetallesPresentacion, DetallesPresentacion>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddRazorPages();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();
            app.Run();
        }
    }
}