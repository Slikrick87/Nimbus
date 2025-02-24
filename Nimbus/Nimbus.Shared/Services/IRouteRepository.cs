using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Services
{
    public interface IRouteRepository
    {
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public void AddRoute(RouteEntity route);
        public RouteEntity CreateNewRoute();
        public List<RouteEntity> GetAllRoutes();
        public RouteEntity GetRouteById(int id);
        public Address AddStop(RouteEntity route, Address address);
        public List<Address> GetStops(int routeId);
        public void LinkTruck(int routeId, int truckId);
    }
}
