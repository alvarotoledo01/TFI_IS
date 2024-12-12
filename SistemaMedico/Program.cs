using SistemaMedico.Services;
using SistemaMedicoV3.Repository;
using SistemaMedicoV3.Services;

var builder = WebApplication.CreateBuilder(args);

// Registro de dependencias
builder.Services.AddSingleton<UsuariosRepository>(); // Registrando UsuariosRepository
builder.Services.AddTransient<AutenticarService>();  // Registrando AutenticarService

// Registrar el servicio PacientesRepository
builder.Services.AddScoped<PacientesRepository>(); // Registrar PacientesRepository con el ciclo de vida adecuado (Scoped)

// Registrar el servicio PacienteService
builder.Services.AddScoped<PacienteService>();  // Registrar PacienteService para que pueda recibir PacientesRepository

// Agregar otros servicios necesarios
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuración de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
