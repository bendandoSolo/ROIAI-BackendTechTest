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
            Parcel parcel1 = new Parcel(1, 1, 1, 1);
            Parcel parcel2 = new Parcel(2, 2, 2, 1);
            List<Parcel> parcels = new List<Parcel>
            {
                parcel1,
                parcel2
            };
            Order order = new Order(parcels);

            //act
            ParcelTypeService parcelType = new();
            ParcelCostService parcelCostService = new(parcelType);
            OrderResponse orderResponse = parcelCostService.GetOrderCost(order);

            //assert    
            Assert.Equal(2, orderResponse.ParcelResponses.Count);
            Assert.Equal(6, orderResponse.DeliveryCost);
            Assert.Equal(12, orderResponse.SpeedyDeliveryCost);
        }

        [Fact]
        public void OrderWithFourSmallParcelsGetsDiscounted()
        {
            //arrange
            Parcel parcel1 = new Parcel(1, 1, 1, 1);
            Parcel parcel2 = new Parcel(2, 2, 2, 1);
            Parcel parcel3 = new Parcel(2, 2, 2, 1); 
            Parcel parcel4 = new Parcel(2, 2, 2, 1);
            List<Parcel> parcels = new List<Parcel>
            {
                parcel1,
                parcel2,
                parcel3,
                parcel4,
            };
            Order order = new Order(parcels);

            //act
            ParcelTypeService parcelType = new();
            ParcelCostService parcelCostService = new(parcelType);
            OrderResponse orderResponse = parcelCostService.GetOrderCost(order);

            //assert
            Assert.Equal(4, orderResponse.ParcelResponses.Count);
            Assert.Equal(3, orderResponse.Discount);
            Assert.Equal(9, orderResponse.DeliveryCost);
            Assert.Equal(21, orderResponse.SpeedyDeliveryCost);
        }

        [Fact]
        public void OrderWithThreeMediumParcelsGetsDiscounted()
        {
            //arrange
            Parcel parcel1 = new Parcel(12, 1, 1, 1);
            Parcel parcel2 = new Parcel(12, 2, 2, 1);
            Parcel parcel3 = new Parcel(12, 2, 2, 1);
            List<Parcel> parcels = new List<Parcel>
            {
                parcel1,
                parcel2,
                parcel3,
            };
            Order order = new Order(parcels);

            //act
            ParcelTypeService parcelType = new();
            ParcelCostService parcelCostService = new(parcelType);
            OrderResponse orderResponse = parcelCostService.GetOrderCost(order);

            //assert
            Assert.Equal(3, orderResponse.ParcelResponses.Count);
            Assert.Equal(8, orderResponse.Discount);
            Assert.Equal(24, orderResponse.DeliveryCost);
            Assert.Equal(56, orderResponse.SpeedyDeliveryCost);
        }

        [Fact]
        public void OrderWithFiveParcelsGetsCheapestOneDiscounted()
        {
            //arrange
            Parcel parcel1 = new Parcel(12, 1, 1, 1);
            Parcel parcel2 = new Parcel(12, 2, 2, 1);
            Parcel parcel3 = new Parcel(12, 2, 2, 1);
            Parcel parcel4 = new Parcel(1, 2, 2, 1);
            Parcel parcel5 = new Parcel(1, 2, 2, 1);
            List<Parcel> parcels = new List<Parcel>
            {
                parcel1,
                parcel2,
                parcel3,
                parcel4,
                parcel5
            };
            Order order = new Order(parcels);

            //act
            ParcelTypeService parcelType = new();
            ParcelCostService parcelCostService = new(parcelType);
            OrderResponse orderResponse = parcelCostService.GetOrderCost(order);

            //assert
            Assert.Equal(5, orderResponse.ParcelResponses.Count);
            Assert.Equal(4, orderResponse.Discount);
            Assert.Equal(27, orderResponse.DeliveryCost);
            Assert.Equal(57, orderResponse.SpeedyDeliveryCost);
        }





    }
}
