using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Services;
using Nimbus.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public TruckRepository(DataContext context)
        {
            _context = context;
        }
        public void AddTruck(TruckEntity truck)
        {

            _context.Trucks.Add(truck);
            _context.SaveChanges();
        }
        //public void SetselectedTruck(TruckEntity truck)
        //{
        //    selectedTruck = truck;
        //}
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
            return _context.Trucks.Find(id); 
        }
        public void AdjustMileage(int id, int mileage)
        {
            TruckEntity truck = GetTruckById(id);
            int difference = mileage - truck.mileage;
            truck.tireFD += difference;
            truck.tireRD += difference;
            truck.tireFP += difference;
            truck.tireRP += difference;
            truck.oilChange += difference;
            truck.mileage = mileage;
            _context.SaveChanges();
        }
        public void LinkRoute(int truckId, int routeId)
        {
            TruckEntity truck = GetTruckById(truckId);
            RouteEntity route = _context.Routes.Find(routeId);
            Task.Run(() => truck.route = route);
            _context.SaveChangesAsync();
        }
        public void ResetMileage(TruckEntity truck, String choice)
        {
            //TruckEntity truck = GetTruckById(selectedId);
            switch (choice)
            {
                case "oil":
                    truck.oilChange = 0;
                    break;
                case "tireFD":
                    truck.tireFD = 0;
                    break;
                case "tireRD":
                    truck.tireRD = 0;
                    break;
                case "tireFP":
                    truck.tireFP = 0;
                    break;
                case "tireRP":
                    truck.tireRP = 0;
                    break;
                case "all":
                    truck.oilChange = 0;
                    truck.tireFD = 0;
                    truck.tireRD = 0;
                    truck.tireFP = 0;
                    truck.tireRP = 0;
                    break;
            }
            _context.SaveChanges();
        }

    }
}
