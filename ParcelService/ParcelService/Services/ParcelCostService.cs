using ParcelService.Interfaces;
using ParcelService.Models;
using System.Runtime.InteropServices;

namespace ParcelService.Services
{
    public class ParcelCostService : IParcelCostService
    {
        private readonly IParcelTypeService _parcelTypeService;
        public ParcelCostService(IParcelTypeService parcelTypeService)
        {
            _parcelTypeService = parcelTypeService;
        }
        public ParcelResponse GetParcelCost(Parcel parcel)
        {
           throw new NotImplementedException();
        }
    }
}
