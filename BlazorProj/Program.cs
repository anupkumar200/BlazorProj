using BlazorProj.Authentication;
using BlazorProj.Clients;
using BlazorProj.Clients.Families;
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

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddSingleton<RelationService>();
builder.Services.AddSingleton<FamilyService>();
builder.Services.AddSingleton<CampaignClients>();
builder.Services.AddSingleton<UserClients>();
builder.Services.AddSingleton<GroceryStoreClients>();
builder.Services.AddScoped<AuthenticationStateProvider,CustomAuthStateProvider>();
builder.Services.AddSingleton<ProgramClients>();
builder.Services.AddScoped<CustomAuthStateProvider>();
builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddAuthorization();
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

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app
    .MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
