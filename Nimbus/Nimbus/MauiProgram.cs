using Microsoft.Extensions.Logging;
using Nimbus.Services;
using Nimbus.Shared;
using Nimbus.Shared.Logic;

//using Nimbus.Web.Services;
using Nimbus.Shared.Services;

namespace Nimbus
{
    //public static class ServiceLocator
    //    {
    //        public static IServiceProvider ServiceProvider { get; set; }
    //        public static IServiceCollection Services { get; set; } = new ServiceCollection();
    //    }
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            // Add device-specific services used by the Nimbus.Shared project
            //var serviceProvider = ServiceDependencyProvider.CreateServiceCollection();
            //builder.Services.AddSingleton(serviceProvider);

            builder.Services.AddSingleton<IFormFactor, FormFactor>();
            builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
            //builder.Services.AddSingleton<ITruckRepository, TruckRepository>();
            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
