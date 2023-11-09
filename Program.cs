using BancaApi.DbContexts;
using BancaApi.Profiles;
using BancaApi.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<BancaInfoContext>(cfg =>
{
    var connectionString = "server=localhost;port=3308;user=root;password=test123;database=bancaApi";

    ServerVersion sv = ServerVersion.AutoDetect(connectionString);
    var serverVersion = new MySqlServerVersion(sv.Version);

    cfg.UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors();

});

// Registra il tuo repository e AutoMapper
builder.Services.AddScoped<IBancaRepository, BancaRepository>();
builder.Services.AddScoped<IContoRepository, ContoRepository>();
builder.Services.AddScoped<IOperazioneRepository, OperazioneRepository>();
builder.Services.AddScoped<IUtenteRepository, UtenteRepository>();
builder.Services.AddScoped<IFuncRepo, FuncRepo>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(UtenteProfile));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
