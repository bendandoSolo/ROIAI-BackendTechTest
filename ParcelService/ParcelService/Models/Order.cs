using ParcelService.Interfaces;

namespace ParcelService.Models
{
    //input model
    public class Order : IHasId<string>
    {
        public Order(List<Parcel> parcels)
        {
            Id = Guid.NewGuid().ToString();
            Parcels = parcels;
        }

        public string Id { get; set; }
        public IList<Parcel> Parcels { get; set; }

        // delivery address - outside of scope

        // pickup address - outside of scope

    }
}
