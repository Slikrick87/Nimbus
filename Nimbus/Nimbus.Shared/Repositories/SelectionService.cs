using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Repositories
{
    public class SelectionService
    {
        public RouteEntity? selectedRoute { get; set; }
        //public List<Address>? currentStops { get; set; }
        public TruckEntity? selectedTruck { get; set; }
    }
}
