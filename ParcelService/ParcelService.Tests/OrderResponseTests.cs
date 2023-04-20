using ParcelService.Extensions;
using ParcelService.Models;
using ParcelService.Services;

namespace ParcelService.Tests
{
    public class OrderResponseTests
    {
        [Fact]
        public void OrderGetsConvertedIntoOrderResponseObject()
        {
            //arrange
            Parcel parcel1 = new Parcel(1, 1, 1);
            Parcel parcel2 = new Parcel(2, 2, 2);
            List<Parcel> parcels = new List<Parcel>
            {
                parcel1,
                parcel2
            };
            Order order = new Order(parcels);

            //covert order to order response.
            ParcelTypeService parcelType = new();
            ParcelCostService parcelCostService = new(parcelType);

            OrderResponse orderResponse = parcelCostService.GetOrderCost(order);

            Assert.Equal(2, orderResponse.ParcelResponses.Count);
            Assert.Equal(6, orderResponse.DeliveryCost);
            Assert.Equal(12, orderResponse.SpeedyDeliveryCost);
        }




    }
}
