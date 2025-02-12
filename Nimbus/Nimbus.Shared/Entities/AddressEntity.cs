using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Entities
{
    public class Address
    {
        [Key]
        public int id;
        [Required]
        public int streetNumber;
        [Required]
        public string streetName;
        [Required]
        public string city;
        [Required]
        public string state;
        [Required]
        public int zipCode;
        //public bool? isDelivered;
        //public DateTime? timeDelivered;

        public Address() { }

        public Address(int streetNumber, string streetName, string city, string state, int zipCode)
        {
            this.streetNumber = streetNumber;
            this.streetName = streetName;
            this.city = city;
            this.state = state;
            this.zipCode = zipCode;
            //this.isDelivered = false;
        }
    }
}
