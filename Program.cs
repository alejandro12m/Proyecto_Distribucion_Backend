using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Distribucion.Core.Interfaces;
using Distribucion.Infraestructura.Repositorio;
using Distribucion.Infraestructura.Data;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Leer DATABASE_URL de Railway
var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");

var connectionString = databaseUrl != null
    ? ConvertPostgresUrlToConnectionString(databaseUrl)
    : builder.Configuration.GetConnectionString("DistribucionContext");

// Inyectar el contexto
builder.Services.AddDbContext<DistribucionContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("myApp", policibuilder =>
    {
        policibuilder.AllowAnyOrigin();
        policibuilder.AllowAnyHeader();
        policibuilder.AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IEnvioRepositorio, EnvioRepositorio>();
builder.Services.AddScoped<IDetalleEnvioRepositorio, DetalleEnvioRepositorio>();

var app = builder.Build();

// Aplicar migraciones automáticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DistribucionContext>();
    db.Database.Migrate();
}

// quitar https redirection en Railway
// app.UseHttpsRedirection();

app.UseCors("myApp");
app.UseAuthorization();
app.MapControllers();
app.Run();


// Función para convertir DATABASE_URL
static string ConvertPostgresUrlToConnectionString(string url)
{
    var uri = new Uri(url);
    var userInfo = uri.UserInfo.Split(':');

    return $"Host={uri.Host};Port={uri.Port};Database={uri.AbsolutePath.TrimStart('/')};Username={userInfo[0]};Password={userInfo[1]};SslMode=Require;Trust Server Certificate=true";
}
