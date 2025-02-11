//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Microsoft.Extensions.DependencyInjection;
//using Nimbus.Shared.Entities;
//using Nimbus.Shared.Logic;
//using Nimbus.Shared.Repositories;

//namespace Nimbus.Shared.Services
//{
//    public class ServiceDependencyProvider
//    {
//        public static IServiceProvider CreateServiceCollection()
//        {
//            var services = new ServiceCollection();

//            services.AddDbContext<TruckContext>();
//            services.AddTransient<IAddressRepository, AddressRepository>()
//            .AddTransient<IRouteRepository, RouteRepository>()
//            .AddTransient<ITruckRepository, TruckRepository>()
//            .BuildServiceProvider();

//            return services.BuildServiceProvider();

//        }

//    }
//}
