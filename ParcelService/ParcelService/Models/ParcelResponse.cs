using ParcelService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Models
{
    public class ParcelResponse : IHasId<string>
    {
        public ParcelResponse(ParcelType type, decimal cost) {
            Id = Guid.NewGuid().ToString();
            ParcelType = type;
            DeliveryCost = cost;
        }
        public string Id { get; set; }
        public ParcelType ParcelType { get; set; }
        public decimal DeliveryCost { get; set; }
    }
}
