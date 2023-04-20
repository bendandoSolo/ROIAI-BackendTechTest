using ParcelService.Models;
using ParcelService.Services;

namespace ParcelService.Tests
{
    public class ParcelTests
    {
        [Theory]
        [InlineData(0, 0, 0, 1, ParcelType.Small)]
        [InlineData(12, 12, 12, 1, ParcelType.Medium)]
        [InlineData(99, 12, 12, 1, ParcelType.Large)]
        [InlineData(99, 122, 12, 1, ParcelType.XL)]
        public void CalculateParcelType(decimal width, decimal height, decimal depth, decimal weight, ParcelType type)
        {
            //arrange
            Parcel parcel = new(width, height, depth, weight);
            ParcelTypeService parcelTypeService = new();

            //act
            ParcelType parcelType = parcelTypeService.GetParcelType(parcel);

            //assert
            Assert.Equal(parcelType, type);
        }

        [Theory]
        [InlineData(0, 0, 0, 1, 3, ParcelType.Small)]
        [InlineData(12, 12, 12, 1, 8, ParcelType.Medium)]
        [InlineData(99, 12, 12, 1, 15, ParcelType.Large)]
        [InlineData(99, 122, 12, 1, 25, ParcelType.XL)]
        public void CalculateParcelCost(decimal width, decimal height, decimal depth,  decimal weight, decimal expectedCost, ParcelType expectedType)
        {
            //arrange
            Parcel parcel = new(width, height, depth, weight);
            ParcelTypeService parcelTypeService = new();
            ParcelCostService parcelCostService = new ParcelCostService(parcelTypeService);

            //act
            ParcelResponse parcelResponse = parcelCostService.GetParcelCost(parcel);

            //assert
            Assert.Equal(expectedCost, parcelResponse.DeliveryCost );
            Assert.Equal(parcelResponse.ParcelType, expectedType);
        }

        [Theory]
        [InlineData(1, 1, 1, 2, 5, ParcelType.Small)]
        [InlineData(12, 12, 12, 5, 12, ParcelType.Medium)]
        [InlineData(99, 12, 12, 10, 23, ParcelType.Large)]
        [InlineData(99, 122, 12, 20, 45, ParcelType.XL)]
        public void CalculateOverweightParcelCost(decimal width, decimal height, decimal depth, decimal weight, decimal expectedCost, ParcelType expectedType)
        {
            //arrange
            Parcel parcel = new(width, height, depth, weight);
            ParcelTypeService parcelTypeService = new();
            ParcelCostService parcelCostService = new ParcelCostService(parcelTypeService);

            //act
            ParcelResponse parcelResponse = parcelCostService.GetParcelCost(parcel);

            //assert
            Assert.Equal(parcelResponse.DeliveryCost, expectedCost);
            Assert.Equal(parcelResponse.ParcelType, expectedType);
        }

    }
}