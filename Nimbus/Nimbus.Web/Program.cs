using FluentAssertions.Common;
using Microsoft.Extensions.DependencyInjection;
using Nimbus;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using Nimbus.Web.Components;
using Nimbus.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Add device-specific services used by the Nimbus.Shared project
//var serviceProvider = ServiceDependencyProvider.CreateServiceCollection();
//builder.Services.AddSingleton(serviceProvider);
//builder.Services.AddDbContext<TruckContext>();

builder.Services.AddSingleton<IFormFactor, FormFactor>()
.AddSingleton<IAddressRepository, AddressRepository>()
.AddSingleton<ITruckRepository, TruckRepository>()
.AddSingleton<IRouteRepository, RouteRepository>()
.AddSingleton<TempService>();

//services.AddDbContext<TruckContext>(Options =>
//Options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(
        typeof(Nimbus.Shared._Imports).Assembly,
        typeof(Nimbus.Web.Client._Imports).Assembly);

app.Run();
