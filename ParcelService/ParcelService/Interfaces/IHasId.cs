namespace ParcelService.Interfaces
{
    public interface IHasId<T>
    {
        T Id { get; set; }
    }
}
