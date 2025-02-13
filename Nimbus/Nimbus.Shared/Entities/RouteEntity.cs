using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Entities
{
    public class RouteEntity
    {
        [Key] public int Id { get; set; }
        public string? nickName;
        //[Required]
        //[ForeignKey("Truck")]
        //public TruckEntity? truckId;
        public ICollection<Address> stops;

        public RouteEntity() { }
    }
}
