using Nimbus.Shared.Services;
using Nimbus.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Nimbus.Shared.Services
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressRepository _addressContext;
        public DbSet<Address> addresses { get; set; }
        public DbSet<Route> routes { get; set; }
        public DbSet<TruckEntity> trucks { get; set; }
        public AddressRepository(AddressRepository addressContext)
        {
            _addressContext = addressContext;
        }
        public void AddStop(Address address)
        {
            addresses.Add(address);
           // _addressContext.SaveChanges();
        }
        public Address CreateNewAddress(int streetNumber, string streetName, string city, string state, int zip)
        {
            //Address address = new Address(streetNumber, streetName, city, state, zip);
            return new Address(streetNumber, streetName, city, state, zip);
        }
        public List<Address> GetAllAddresses()
        {
            return _addressContext.addresses.ToList();
        }
        public Address GetAddressById(int id)
        {
            try { return _addressContext.addresses.Find(id); }
            catch { return null; }
        }

        }
}
