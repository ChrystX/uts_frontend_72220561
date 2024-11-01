using uts_frontend_72220561.Components;
using uts_frontend_72220561.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Register typed HttpClient for both services.
builder.Services.AddHttpClient<CategoryService>(client =>
{
    client.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/");
});

builder.Services.AddSingleton<ThemeService>();

builder.Services.AddHttpClient<CourseService>(client =>
{
    client.BaseAddress = new Uri("https://actualbackendapp.azurewebsites.net/");
});

// Remove unnecessary HttpClient registrations.
// No need for another generic HttpClient here.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts(); // Optional: Configurable based on production environment needs.
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// Map Razor Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
