using Microsoft.EntityFrameworkCore;
using TotemPWA.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add SQL Server Connection 
builder.Services.AddDbContext<AppDbContext>(options =>
    // options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"))
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLLiteConnection"))
);

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Adiciona o Swagger

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    // Apaga o banco de dados completamente
    // context.Database.EnsureDeleted(); 

    // Aplica as migrações do zero
    // context.Database.Migrate();       

    // Executa o Seed (inicialização de dados)
    // await DbInitializer.InitializeAsync(context);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production 
    // scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();  // Habilita o Swagger
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TotemPWA API v1"));  // Interface do Swagger

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "totem",
    pattern: "{controller=Menu}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
