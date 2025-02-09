using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Services
{
    public interface IAddressRepository
    {
        //public List<Address> addresses;
        public void AddStop(Address address);
        public Address CreateNewAddress(int streetNumber, string streetName, string city, string state, int zip);
        public List<Address> GetAllAddresses();
    }
}
