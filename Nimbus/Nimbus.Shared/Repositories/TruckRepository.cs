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
        private readonly TruckRepository _truckContext;
        public DbSet<Address> addresses { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public TruckRepository(TruckRepository truckContext)
        {
            _truckContext = truckContext;
        }
        public void AddTruck(TruckEntity truck)
        {

            trucks.Add(truck);
        }
        public TruckEntity CreateNewTruck(int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil)
        {
            TruckEntity truck = new TruckEntity(mileage, tireFD, tireRD, tireFP, tireRP, oil);
            return truck;
        }
        public List<TruckEntity> GetAllTrucks()
        {
            return _truckContext.trucks.ToList();
        }
        public TruckEntity GetTruckById(int id)
        {
            try { return _truckContext.trucks.Find(id); }
            catch { return null; }
        }
    }
}
