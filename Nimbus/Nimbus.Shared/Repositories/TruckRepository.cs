using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Logic
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public TruckRepository(DataContext context)
        {
            _context = context;
        }
        public void AddTruck(TruckEntity truck)
        {

            _context.Trucks.Add(truck);
        }
        public TruckEntity CreateNewTruck(int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil)
        {
            TruckEntity truck = new TruckEntity(mileage, tireFD, tireRD, tireFP, tireRP, oil);
            return truck;
        }
        public List<TruckEntity> GetAllTrucks()
        {
            return _context.Trucks.ToList();
        }
        public TruckEntity GetTruckById(int id)
        {
            try { return _context.Trucks.Find(id); }
            catch { return null; }
        }
    }
}
