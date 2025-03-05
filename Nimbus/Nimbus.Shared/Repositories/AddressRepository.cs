using Nimbus.Shared.Services;
using Nimbus.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using Nimbus.Shared.Repositories;

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
        public async Task AddStopAsync(Address address)
        {
           await Task.Run(() => _context.Addresses.Add(address));
           Task taskTwo = Task.Run(() => _context.SaveChangesAsync());
        }
        public async Task<Address> CreateNewAddressAsync(int streetNumber, string streetName, string city, string state, int zip)
        {
            Address address = await Task.Run(() => 
                address = new Address(streetNumber, streetName, city, state, zip));

            return address;
        }
        public async Task<Address> CreateNewAddressWithRouteAsync(int streetNumber, string streetName, string city, string state, int zip, RouteEntity route)
        {
            Address address = await Task.Run(() => 
                new Address(streetNumber, streetName, city, state, zip, route));
            
            return address;
        }
        public async Task<List<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }
        public async Task<Address> GetAddressByIdAsync(int id)
        {
            try { return await _context.Addresses.FindAsync(id); }
            catch { return null; }
        }
        public async Task<List<Address>> GetAddressesByRoute(int routeId)
        {
            List<Address> addresses = await Task.Run(() => _context.Addresses.Where(a => a.routeId == routeId).ToList());
            return addresses;
        }
        public async Task ConvertToJSAddressByRoute(int routeId)
        {
            List<Address> addresses = GetAddressesByRoute(routeId).Result;
            string jsAddress;
            int counter = 0;
            foreach (var item in addresses)
            {
                counter += 1;
                string streetNumber = item.streetNumber.ToString();
                string streetName = item.streetName;
                string city = item.city;
                string state = item.state;
                string zip = item.zipCode.ToString();
                string fullAddress = streetNumber + "+" + streetName + "+" + city + "+" + state + "+" + zip;
                    if (counter < addresses.Count())
                {
                    fullAddress += "|";
                }

            }

        }
        public async Task GetCordinatesOfAddress()
        {

        }

        }
}
