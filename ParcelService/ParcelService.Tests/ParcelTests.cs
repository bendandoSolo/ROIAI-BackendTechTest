using ParcelService.Models;
using ParcelService.Services;

namespace ParcelService.Tests
{
    public class ParcelTests
    {
        [Theory]
        [InlineData(0, 0, 0, ParcelType.Small)]
        [InlineData(12, 12, 12, ParcelType.Medium)]
        [InlineData(99, 12, 12, ParcelType.Large)]
        [InlineData(99, 122, 12, ParcelType.XL)]
        public void CalculateParcelType(decimal width, decimal height, decimal depth, ParcelType type)
        {
            //arrange
            Parcel parcel = new(width, height, depth);
            ParcelTypeService parcelTypeService = new();

            //act
            ParcelType parcelType = parcelTypeService.GetParcelType(parcel);

            //assert
            Assert.Equal(parcelType, type);
        }
    }
}