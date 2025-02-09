using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Entities
{
    public class TruckEntity
    {
        public int id;
        public int mileage;
        public int tireFD;
        public int tireRD;
        public int tireFP;
        public int tireRP;
        public int oilChange;
        [ForeignKey("Route")]
        public int routeId;
        public TruckEntity(int mileage, int tireFD, int tireRD, int tireFP, int tireRP, int oil)
        {
            //this.id = id;
            this.mileage = mileage;
            this.tireFD = tireFD;
            this.tireRD = tireRD;
            this.tireFP = tireFP;
            this.tireRP = tireRP;
            this.oilChange = oil;
        }
    }
}
