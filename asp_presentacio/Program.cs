using lib_comunicaciones.Implementaciones;

var builder = WebApplication.CreateBuilder(args);

var datos = new Dictionary<string, object>();
var PersonasComunicacion = new PersonasComunicacion();
var task = PersonasComunicacion.Listar(datos);
task.Wait();
var respuesta = task.Result;

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();