using ParcelService.Interfaces;
using ParcelService.Models;

namespace ParcelService.Services
{
    public class ParcelTypeService : IParcelTypeService
    {
        public ParcelType GetParcelType(Parcel parcel)
        {
            if (parcel.Width < 10 && parcel.Height < 10 && parcel.Depth < 10)
                return ParcelType.Small;
            if (parcel.Width < 50 && parcel.Height < 50 && parcel.Depth < 50)
                return ParcelType.Medium;
            if (parcel.Width < 100 && parcel.Height < 100 && parcel.Depth < 100)
                return ParcelType.Large;
            else
                return ParcelType.XL;
        }
    }
}
