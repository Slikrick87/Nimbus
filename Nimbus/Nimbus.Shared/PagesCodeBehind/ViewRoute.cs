using Nimbus.Shared.Entities;
using Nimbus.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    partial class ViewRoute
    {
        public int routeId;
        //RouteEntity route;
        List<Address> allStops = new List<Address>();
        //public async Task<List<Address>> GetRouteAsync()
        //{

        //    allStops = await Task.Run(() => RouteRepository.GetStopsAsync(routeId));
        //    return allStops;
        //}
        protected override async Task OnInitializedAsync()
        {
            allStops = await Task.Run(() => RouteRepository.GetStopsAsync(SelectionService.selectedRoute.Id));
            
        }
    }
}
