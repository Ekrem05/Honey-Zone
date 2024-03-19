namespace HoneyZoneMvc.BusinessLogic.Contracts.SubContracts
{
    public interface IAddable<T>
    {
        Task AddAsync(T model);

    }
}
