using BlazorProj.Authentication;
using BlazorProj.Clients;
using BlazorProj.Clients.GroceryStore;
using BlazorProj.Clients.Programs;
using BlazorProj.Clients.User;
using BlazorProj.Components;
using BlazorProj.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents();
//builder.Services.AddDbContext<ApplicationDbContext>(options => 
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "auth_token";
//        options.LoginPath = "/login";
//        options.Cookie.MaxAge = TimeSpan.FromMinutes(20);
//        options.AccessDeniedPath = "/access-denied";
//    });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddSingleton<CampaignClients>();
builder.Services.AddSingleton<UserClients>();
builder.Services.AddSingleton<GroceryStoreClients>();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddSingleton<ProgramClients>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddAuthentication();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app
    .MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
