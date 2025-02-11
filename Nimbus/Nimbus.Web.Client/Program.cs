using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Nimbus.Shared.Services;
using Nimbus.Web.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Add device-specific services used by the Nimbus.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();
//.AddSingleton<IAddressRepository, AddressRepository>();

await builder.Build().RunAsync();
