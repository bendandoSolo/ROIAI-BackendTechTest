using ParcelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Interfaces
{
    public interface IParcelCostService
    {
        public ParcelResponse GetParcelCost(Parcel parcel);
    }
}

