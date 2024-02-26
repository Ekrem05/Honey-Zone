namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface ICrud<T>
    {
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<ICollection<T>> GetAllAsync();
        Task<bool> UpdateAsync(T entity);
    }
}
