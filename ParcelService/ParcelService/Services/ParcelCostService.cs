﻿using ParcelService.Interfaces;
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
            var type = _parcelTypeService.GetParcelType(parcel);
            decimal cost = 0;
            switch (type)
            {
                case ParcelType.Small:
                    cost += 3;
                    break;
                case ParcelType.Medium:
                    cost += 8;
                    break;
                case ParcelType.Large:
                    cost += 15;
                    break;
                case ParcelType.XL:
                    cost += 25;
                    break;
                default:
                    throw new Exception();
            }
            return new ParcelResponse(type, cost);
        }
    }
}
