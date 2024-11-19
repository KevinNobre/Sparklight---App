using Microsoft.EntityFrameworkCore;
using Sparklight.Data;
using Sparklight.Domain.Repositories;
using Sparklight.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar o DbContext com a string de conexão do Oracle
builder.Services.AddDbContext<SparklightDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));


// Registra os repositórios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAparelhoRepository, AparelhoRepository>();
builder.Services.AddScoped<IHistoricoRepository, HistoricoRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IPontuacaoRepository, PontuacaoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Aparelho}/{action=Index}/{id?}");

app.Run();
