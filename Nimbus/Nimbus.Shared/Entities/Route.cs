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
    public class Route
    {
        [Key] public int Id { get; set; }
        [Required]
        [ForeignKey("Truck")]
        public int truckId;
        public ICollection<Address> stops;
    }
}
