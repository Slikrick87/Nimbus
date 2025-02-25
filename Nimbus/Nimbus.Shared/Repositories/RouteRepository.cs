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
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public RouteRepository(DataContext context)
        {
            _context = context;
        }
        public void AddRoute(RouteEntity route)
        {

            _context.Routes.Add(route);
            _context.SaveChanges();
        }
        public RouteEntity CreateNewRoute()
        {
            RouteEntity route = new RouteEntity();
            return route;
        }
        public List<RouteEntity> GetAllRoutes()
        {
            return _context.Routes.ToList();
        }
        public RouteEntity GetRouteById(int id)
        {
            return _context.Routes.Find(id); 
        }
        public Address AddStop(RouteEntity route, Address address)
        {
            _context.Addresses.Add(address);
            //route.stops.Add(address);
            _context.SaveChanges();
            return address;
        }
        public List<Address> GetStops(int routeId)
        {
            return _context.Addresses.Where(a => a.id == routeId).ToList();
        }
        public void LinkTruck(int routeId, int truckId)
        {
            RouteEntity route = GetRouteById(routeId);
            TruckEntity truck = _context.Trucks.Find(truckId);
            route.truck = truck;
            _context.SaveChanges();
        }
    }
}
