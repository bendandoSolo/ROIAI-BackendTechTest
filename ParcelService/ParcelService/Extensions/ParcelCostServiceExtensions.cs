using ParcelService.Interfaces;
using ParcelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Extensions
{
    //extension method choosen to allow interface to remain as small as possible, but the functionality wide
    public static class ParcelCostServiceExtensions
    {
        public static OrderResponse GetOrderCost(this IParcelCostService parcelCostService, Order order)
        {
            var response = new OrderResponse
            {
                ParcelResponses = order.Parcels.Select(p => parcelCostService.GetParcelCost(p)).ToList(),
            };
            response.AdditionalSpeedyDeliveryCost = response.DeliveryCost;
            //loop through parcel response to calculate discounts
            return response;
        }
    }
}
