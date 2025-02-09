using Nimbus.Shared.Services;

namespace Nimbus.Shared.Services
{
    public class AddressRepository : IAddressRepository
    {
        public List<Address> addresses = new List<Address>();
        public void AddStop(Address address)
        {
            
            addresses.Add(address);
        }
        public Address CreateNewAddress(int streetNumber, string streetName, string city, string state, int zip)
        {
            Address address = new Address(streetNumber, streetName, city, state, zip);
            return new Address(streetNumber, streetName, city, state, zip);
        }
        public List<Address> GetAllAddresses()
        {
            return addresses;
        }
    }
}
