using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly RouteRepository _routeContext;
        public DbSet<Address> addresses { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public RouteRepository(RouteRepository routeContext)
        {
            _routeContext = routeContext;
        }
        public void AddRoute(Route route)
        {

            routes.Add(route);
        }
        public Route CreateNewRoute(int streetNumber, string streetName, string city, string state, int zip)
        {
            Route route = new Route();
            return route;
        }
        public List<Route> GetAllRoutes()
        {
            return _routeContext.routes.ToList();
        }
        public Route GetRouteById(int id)
        {
            try { return _routeContext.routes.Find(id); }
            catch { return null; }
        }
    }
}
