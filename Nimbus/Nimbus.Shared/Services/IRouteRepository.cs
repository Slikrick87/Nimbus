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
        public DbSet<Route> routes { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public void AddRoute(Route route);
        public Route CreateNewRoute(int streetNumber, string streetName, string city, string state, int zip);
        public List<Route> GetAllRoutes();
        public Route GetRouteById(int id);
    }
}
