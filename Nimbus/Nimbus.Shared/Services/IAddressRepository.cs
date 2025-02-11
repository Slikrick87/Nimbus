using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Entities;

namespace Nimbus.Shared.Services
{
    public interface IAddressRepository
    {
        public DbSet<Address> addresses { get; set;  }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public void AddStop(Address address);
        public Address CreateNewAddress(int streetNumber, string streetName, string city, string state, int zip);
        public List<Address> GetAllAddresses();
        public Address GetAddressById(int id);
    }
}
