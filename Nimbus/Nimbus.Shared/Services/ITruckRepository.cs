﻿using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nimbus.Shared.Logic;

namespace Nimbus.Shared.Services
{
    public interface ITruckRepository
    {
        //public TruckEntity currentTruck { get; set; }
        public DbSet<Address> addresses {  get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        //public void SetCurrentTruck(TruckEntity truck);
        public void AddTruck(TruckEntity truck);
        public TruckEntity CreateNewTruck(int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil);
        public List<TruckEntity> GetAllTrucks();
        public TruckEntity GetTruckById(int id);

    }
}
