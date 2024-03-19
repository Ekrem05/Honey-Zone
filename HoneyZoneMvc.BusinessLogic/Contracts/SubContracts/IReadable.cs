namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IReadable<T> where T : class
    {
        Task<IEnumerable<T>> AllAsync();
        Task<T> GetByIdAsync(string Id);
    }
}