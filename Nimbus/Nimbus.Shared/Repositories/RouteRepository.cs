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
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public RouteRepository(DataContext context)
        {
            _context = context;
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
            return _context.Routes.ToList();
        }
        public Route GetRouteById(int id)
        {
            return _context.Routes.Find(id); 
        }
    }
}
