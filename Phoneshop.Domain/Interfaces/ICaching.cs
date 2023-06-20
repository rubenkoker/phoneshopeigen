namespace Phoneshop.Domain.Interfaces
{
    public interface ICaching<TItem>
    {
        Task<TItem> GetOrCreate(object key, Func<TItem> createItem);
    }
}