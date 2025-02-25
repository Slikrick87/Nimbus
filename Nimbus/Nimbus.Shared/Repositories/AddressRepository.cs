using Nimbus.Shared.Services;
using Nimbus.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nimbus.Shared.Services
{
    public class AddressRepository : IAddressRepository
    {
        private readonly DataContext _context;
        public DbSet<Address> addresses { get; set; }
        public DbSet<RouteEntity> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public AddressRepository(DataContext context)
        {
            _context = context;
        }
        public void AddStop(Address address)
        {
            _context.Addresses.Add(address);
           _context.SaveChanges();
        }
        public Address CreateNewAddress(int streetNumber, string streetName, string city, string state, int zip)
        {
            Address address = new Address(streetNumber, streetName, city, state, zip);
            return address/*new Address(streetNumber, streetName, city, state, zip)*/;
        }
        public Address CreateNewAddressWithRoute(int streetNumber, string streetName, string city, string state, int zip, RouteEntity route)
        {
            Address address = new Address(streetNumber, streetName, city, state, zip, route);
            return address/*new Address(streetNumber, streetName, city, state, zip)*/;
        }
        public List<Address> GetAllAddresses()
        {
            return _context.Addresses.ToList();
        }
        public Address GetAddressById(int id)
        {
            try { return _context.Addresses.Find(id); }
            catch { return null; }
        }
        //public List<Address> GetStops(int id)
        //{
        //    return _context.Addresses
        //}

        }
}
