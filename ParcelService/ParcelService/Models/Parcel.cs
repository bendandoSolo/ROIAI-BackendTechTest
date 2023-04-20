using ParcelService.Interfaces;

namespace ParcelService.Models
{
    public class Parcel : IHasId<string>
    {
        public Parcel(decimal width, decimal height, decimal depth, decimal weight)
        {
            Id = Guid.NewGuid().ToString();
            Width = width;
            Height = height;
            Depth = depth;
            Weight = weight;
        }
        public string Id { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }
    }
}
