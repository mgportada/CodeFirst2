
namespace Domain
{
    public interface IBeerRepository
    {
        Task<int> InsertAsync(Beer beer);
        Task<Beer?> GetAsync(int id);
        Task UpdateAsync(Beer beer);

    }
}
