//using OutdoorCR.Application.Profiles;
//using OutdoorCR.Application.Services.Implementations;
//using OutdoorCR.Application.Services.Interfaces;
using Libreria.Web.Middleware;
//using OutdoorCR.Infraestructure.Repository.Implementations;
//using OutdoorCR.Infraestructure.Repository.Interfaces;
//using OutdoorCR.Web.Middleware;
using Microsoft.EntityFrameworkCore;
using OutdoorCR.Infraestructure.Data;
using Serilog;
using Serilog.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar D.I.
////Repository
//builder.Services.AddTransient<IRepositoryAutor, RepositoryAutor>();
//builder.Services.AddTransient<IRepositoryLibro, RepositoryLibro>();
//builder.Services.AddTransient<IRepositoryOrden, RepositoryOrden>();
////Services
//builder.Services.AddTransient<IServiceAutor, ServiceAutor>();
//builder.Services.AddTransient<IServiceLibro, ServiceLibro>();
//builder.Services.AddTransient<IServiceOrden, ServiceOrden>();
////Configurar Automapper
//builder.Services.AddAutoMapper(config =>
//{
//    config.AddProfile<AutorProfile>();
//    config.AddProfile<CategoriaProfile>();
//    config.AddProfile<ClienteProfile>();
//    config.AddProfile<LibroProfile>();
//    config.AddProfile<OrdenProfile>();
//    config.AddProfile<OrdenDetalleProfile>();
//    config.AddProfile<RolProfile>();
//    config.AddProfile<UsuarioProfile>();
//});


// Configuar Conexión a la Base de Datos SQL
builder.Services.AddDbContext<OutdoorCRContext>(options =>
{
    // it read appsettings.json file
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDataBase"));
    if (builder.Environment.IsDevelopment())
        options.EnableSensitiveDataLogging();
});

//Configuración Serilog
// Logger. P.E. Verbose = muestra SQl Statement
var logger = new LoggerConfiguration()
// Limitar la información de depuración
.MinimumLevel.Override("Microsoft", LogEventLevel.Error)
.Enrich.FromLogContext()
// Log LogEventLevel.Verbose muestra mucha información,pero no es necesaria solo para el proceso de depuración
.WriteTo.Console(LogEventLevel.Information)
.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Information).WriteTo.File(@"Logs\Info-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Debug).WriteTo.File(@"Logs\Debug-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Warning).WriteTo.File(@"Logs\Warning-.log", shared: true, encoding: System.Text.Encoding.ASCII, rollingInterval: RollingInterval.Day))
.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Error).WriteTo.File(@"Logs\Error-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
.WriteTo.Logger(l => l.Filter.ByIncludingOnly(e => e.Level == LogEventLevel.Fatal).WriteTo.File(@"Logs\Fatal-.log", shared: true, encoding: Encoding.ASCII, rollingInterval: RollingInterval.Day))
.CreateLogger();
builder.Host.UseSerilog(logger);
//***************************



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    // Error control Middleware
    app.UseMiddleware<ErrorHandlingMiddleware>();
}

//Activar soporte a la solicitud de registro con SERILOG
app.UseSerilogRequestLogging();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Activar Antiforgery
app.UseAntiforgery();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
