using ParcelService.Models;

namespace ParcelService.Interfaces
{
    public interface IParcelTypeService
    {
        public ParcelType GetParcelType(Parcel parcel);
    }
}
