using Microsoft.AspNetCore.Components;
using Nimbus.Shared.Entities;
using Nimbus.Shared.Logic;
using Nimbus.Shared.Repositories;
using Nimbus.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Pages
{
    partial class SelectRoute
    {
        public RouteEntity? route;
        public TruckEntity? truck;
        public List<RouteEntity> routes = new List<RouteEntity>();
        public async Task ChooseRoute(int id)
        {
            SelectionService.selectedRoute = await RouteRepository.GetRouteByIdAsync(id);
        }
        public async Task LinkTruckAndRouteAsync()
        {
            Task taskOne = Task.Run(() => RouteRepository.LinkTruckAsync(SelectionService.selectedTruck.id, SelectionService.selectedRoute.Id));
            Task taskTwo = Task.Run(() => TruckRepository.LinkRoute(SelectionService.selectedRoute.Id, SelectionService.selectedTruck.id));
            await Task.WhenAll(taskOne, taskTwo);
        }
        protected override async Task OnInitializedAsync()
        {
            routes = await RouteRepository.GetAllRoutesAsync();
        }
    }
}
