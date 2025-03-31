using SGHR.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Dirección base correcta de la API en HTTP
var apiBaseUrl = "http://localhost:5116/";

// Registrar servicios con HttpClient
builder.Services.AddHttpClient<TarifaApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddHttpClient<UsuarioApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});
builder.Services.AddHttpClient<RecepcionApiService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl);
});

// Habilitar controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();