using ParcelService.Interfaces;

namespace ParcelService.Models
{
    //output model
    public class OrderResponse : IHasId<string>
    {
        public OrderResponse()
        {
            Id = Guid.NewGuid().ToString();
            ParcelResponses = new List<ParcelResponse>();
        }
        public string Id { get; set; }
        public IList<ParcelResponse> ParcelResponses { get; set; }
        public decimal TotalCost => (ParcelResponses?.Sum(parcel => parcel.DeliveryCost) ?? 0);
    }
}
